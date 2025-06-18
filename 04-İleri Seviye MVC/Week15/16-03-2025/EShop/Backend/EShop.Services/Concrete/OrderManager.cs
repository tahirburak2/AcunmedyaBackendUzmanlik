using AutoMapper;
using EShop.Data.Abstract;
using EShop.Entity.Concrete;
using EShop.Services.Abstract;
using EShop.Shared.ComplexTypes;
using EShop.Shared.Dtos.OrderDtos;
using EShop.Shared.Dtos.ResponseDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace EShop.Services.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICartService _cartManager;
        private readonly IGenericRepository<Order> _orderRepository;
        private readonly IGenericRepository<Product> _productRepository;

        public OrderManager(IUnitOfWork unitOfWork, IMapper mapper, ICartService cartManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cartManager = cartManager;
            _orderRepository = _unitOfWork.GetRepository<Order>();
            _productRepository = _unitOfWork.GetRepository<Product>();
        }

        public async Task<ResponseDto<OrderDto>> OrderNowAsync(OrderNowDto orderNowDto)
        {
            try
            {
                foreach (var orderItem in orderNowDto.OrderItems)
                {
                    var existsProduct = await _productRepository.GetAsync(x => x.Id == orderItem.ProductId);
                    if (existsProduct == null)
                    {
                        return ResponseDto<OrderDto>.Fail($"{orderItem.ProductId} id'li ürün bulunamadığı için işlem iptal edilmiştir, yeniden deneyiniz", StatusCodes.Status404NotFound);
                    }
                    if (!existsProduct.IsActive)
                    {
                        return ResponseDto<OrderDto>.Fail($"{orderItem.ProductId} id'li ürün aktif olmadığı için işlem iptal edilmiştir", StatusCodes.Status400BadRequest);
                    }

                }
                var order = _mapper.Map<Order>(orderNowDto);
                //Fake ödeme operasyonunu ekleyeceğiz.
                await _orderRepository.AddAsync(order);
                await _unitOfWork.SaveAsync();
                //OrderItem'larla ilgili ekstra bir işlem yapmayıp, bunu izleyip sonuçlarını değerlendireceğiz. Gerekirse buraya gelip yapmamız gerekenleri yapacağız.
                await _cartManager.ClearCartAsync(orderNowDto.ApplicationUserId!);
                var orderDto = _mapper.Map<OrderDto>(order);
                return ResponseDto<OrderDto>.Success(orderDto, StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return ResponseDto<OrderDto>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ResponseDto<NoContent>> CancelOrderAsync(int id)
        {
            try
            {
                var order = await _orderRepository.GetAsync(id);
                if (order == null)
                {
                    return ResponseDto<NoContent>.Fail("İlgili sipariş bulunamadı", StatusCodes.Status404NotFound);
                }

                order.IsDeleted = true;
                order.IsActive = false;
                order.DeletedAt = DateTime.UtcNow;
                _orderRepository.Update(order);
                var result = await _unitOfWork.SaveAsync();
                if (result < 1)
                {
                    return ResponseDto<NoContent>.Fail("İşlem tamamlanamadı", StatusCodes.Status500InternalServerError);
                }
                return ResponseDto<NoContent>.Success(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                return ResponseDto<NoContent>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ResponseDto<IEnumerable<OrderDto>>> GetAllAsync()
        {
            try
            {
                var orders = await _orderRepository.GetAllAsync(
                    orderBy: x => x.OrderByDescending(x => x.CreatedAt),
                    includes: query => query
                                .Include(x => x.ApplicationUser)
                                .Include(x => x.OrderItems)
                                .ThenInclude(y => y.Product));
                if (orders == null || !orders.Any())
                {
                    return ResponseDto<IEnumerable<OrderDto>>.Fail("Herhangi bir sipariş bilgisi bulunamamıştır", StatusCodes.Status404NotFound);
                }
                var orderDtos = _mapper.Map<IEnumerable<OrderDto>>(orders);
                return ResponseDto<IEnumerable<OrderDto>>.Success(orderDtos, StatusCodes.Status200OK);

            }
            catch (Exception ex)
            {
                return ResponseDto<IEnumerable<OrderDto>>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ResponseDto<IEnumerable<OrderDto>>> GetAllAsync(OrderStatus? orderStatus, string? applicationUserId = null)
        {
            try
            {
                var orders =
                    applicationUserId == null ?
                    await _orderRepository.GetAllAsync(
                    predicate: x => !x.IsDeleted && (orderStatus == null || x.OrderStatus == orderStatus),
                    orderBy: x => x.OrderByDescending(x => x.CreatedAt),
                    includes: query => query
                                    .Include(x => x.ApplicationUser)
                                    .Include(x => x.OrderItems)
                                    .ThenInclude(y => y.Product)) :
                    await _orderRepository.GetAllAsync(
                        predicate: x => !x.IsDeleted && (orderStatus == null || x.OrderStatus == orderStatus) && x.ApplicationUserId == applicationUserId,
                        orderBy: x => x.OrderByDescending(x => x.CreatedAt),
                        includes: query => query
                                        .Include(x => x.ApplicationUser)
                                        .Include(x => x.OrderItems)
                                        .ThenInclude(y => y.Product));
                if (orders == null || !orders.Any())
                {
                    return ResponseDto<IEnumerable<OrderDto>>.Fail("Herhangi bir sipariş bilgisi bulunamamıştır", StatusCodes.Status404NotFound);
                }
                var orderDtos = _mapper.Map<IEnumerable<OrderDto>>(orders);
                return ResponseDto<IEnumerable<OrderDto>>.Success(orderDtos, StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return ResponseDto<IEnumerable<OrderDto>>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ResponseDto<IEnumerable<OrderDto>>> GetAllAsync(string applicationUserId)
        {
            try
            {
                var orders = await _orderRepository.GetAllAsync(
                    predicate: x => x.ApplicationUserId == applicationUserId,
                    orderBy: x => x.OrderByDescending(x => x.CreatedAt),
                    includes: query => query
                                    .Include(x => x.ApplicationUser)
                                    .Include(x => x.OrderItems)
                                    .ThenInclude(y => y.Product));
                if (orders == null || !orders.Any())
                {
                    return ResponseDto<IEnumerable<OrderDto>>.Fail("Herhangi bir sipariş bilgisi bulunamamıştır", StatusCodes.Status404NotFound);
                }
                var orderDtos = _mapper.Map<IEnumerable<OrderDto>>(orders);
                return ResponseDto<IEnumerable<OrderDto>>.Success(orderDtos, StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return ResponseDto<IEnumerable<OrderDto>>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ResponseDto<IEnumerable<OrderDto>>> GetAllAsync(DateTime startDate, DateTime endDate)
        {
            try
            {
                startDate = startDate == default ? new DateTime(1900, 1, 1) : startDate;
                var orders = await _orderRepository.GetAllAsync(
                    predicate: x => x.CreatedAt >= startDate && x.CreatedAt <= endDate,
                    orderBy: x => x.OrderByDescending(x => x.CreatedAt),
                    includes: query => query
                                    .Include(x => x.ApplicationUser)
                                    .Include(x => x.OrderItems)
                                    .ThenInclude(y => y.Product));
                if (orders == null || !orders.Any())
                {
                    return ResponseDto<IEnumerable<OrderDto>>.Fail("Herhangi bir sipariş bilgisi bulunamamıştır", StatusCodes.Status404NotFound);
                }
                var orderDtos = _mapper.Map<IEnumerable<OrderDto>>(orders);
                return ResponseDto<IEnumerable<OrderDto>>.Success(orderDtos, StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return ResponseDto<IEnumerable<OrderDto>>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ResponseDto<OrderDto>> GetAsync(int id)
        {
            try
            {
                var order = await _orderRepository.GetAsync(
                    predicate: x => x.Id == id,
                    includes: query => query
                                .Include(x => x.ApplicationUser)
                                .Include(x => x.OrderItems)
                                .ThenInclude(y => y.Product)
                );
                if (order == null)
                {
                    return ResponseDto<OrderDto>.Fail("İlgili sipariş bulunamadı", StatusCodes.Status404NotFound);
                }
                var orderDto = _mapper.Map<OrderDto>(order);
                return ResponseDto<OrderDto>.Success(orderDto, StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return ResponseDto<OrderDto>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ResponseDto<NoContent>> ChangeOrderStatusAsync(int id, OrderStatus orderStatus)
        {
            try
            {
                var order = await _orderRepository.GetAsync(id);
                if (order == null)
                {
                    return ResponseDto<NoContent>.Fail("İlgili sipariş bulunamadı", StatusCodes.Status404NotFound);
                }
                order.OrderStatus = orderStatus;
                order.UpdatedAt = DateTime.UtcNow;
                _orderRepository.Update(order);
                var result = await _unitOfWork.SaveAsync();
                if (result < 1)
                {
                    return ResponseDto<NoContent>.Fail("İşlem tamamlanamadı", StatusCodes.Status500InternalServerError);
                }
                return ResponseDto<NoContent>.Success(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return ResponseDto<NoContent>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }
    }
}
