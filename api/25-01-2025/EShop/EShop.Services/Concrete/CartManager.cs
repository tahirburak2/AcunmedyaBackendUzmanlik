using System;
using AutoMapper;
using EShop.Data.Abstract;
using EShop.Entity.Concrete;
using EShop.Services.Abstract;
using EShop.Shared.Dtos;
using EShop.Shared.Dtos.ResponseDtos;

namespace EShop.Services.Concrete;

public class CartManager : ICartService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IGenericRepository<Cart> _cartRepository;

    public CartManager(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _cartRepository = _unitOfWork.GetRepository<Cart>();
    }

    public Task<ResponseDto<NoContent>> AddToCartAsync(CartItemCreateDto cartItemCreateDto)
    {
        try
        {
            
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }

    public Task<ResponseDto<CartItemDto>> ChangeQuantityAsync(CartItemUpdateDto cartItemUpdateDto)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto<NoContent>> ClearCartAsync(string applicationUserId)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto<CartDto>> CreateCartAsync(string applicationUserId)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto<CartDto>> GetCartAsync(string applicationUserId)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto<NoContent>> RemoveFromCartAsync(int cartItemId)
    {
        throw new NotImplementedException();
    }
}
