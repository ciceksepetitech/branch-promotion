using BranchPromotion.Domain.Constants;
using BranchPromotion.Domain.Entities;
using BranchPromotion.Domain.Exceptions;
using BranchPromotion.Domain.Repositories;
using BranchPromotion.Domain.Services;
using MediatR;

namespace BranchPromotion.Application.Commands.CreatePromotion
{
    public class CreatePromotionCommandHandler : IRequestHandler<CreatePromotionCommand>
    {
        private readonly IBranchPromotionVariantRepository _repository;
        private readonly IValueConverter _valueConverter;

        public CreatePromotionCommandHandler(
            IBranchPromotionVariantRepository repository,
            IValueConverter valueConverter)
        {
            _repository = repository;
            _valueConverter = valueConverter;
        }

        public async Task Handle(CreatePromotionCommand request, CancellationToken cancellationToken)
        {
            var mainCategory = _valueConverter.MapMainCategories(request.MainCategoryIds);
            var branchType = _valueConverter.MapBranchTypes(request.BranchTypes);
            var isExists = await _repository.ExistsAsync(request.VariantId, mainCategory, branchType, request.BranchId, request.SenderBranchId);
            BusinessException.ThrowIf(isExists, MessageConstants.BRANCH_PROMOTION_IS_EXISTS);

            var now = DateTime.Now;
            var variant = new BranchPromotionVariant
            {
                VariantId = request.VariantId,
                VariantCode = request.VariantCode,
                ProductId = request.ProductId,
                ProductName = request.ProductName,
                MainCategory = mainCategory,
                BranchType = branchType,
                BranchId = request.BranchId,
                SenderBranchId = request.SenderBranchId,
                MinimumPrice = request.MinimumPrice,
                MaximumPrice = request.MaximumPrice,
                Sequence = request.Sequence,
                IsActive = request.IsActive,
                CreatedBy = request.UserId,
                CreatedOn = now,
                ModifiedBy = request.UserId,
                ModifiedOn = now
            };

            await _repository.InsertAsync(variant);
        }
    }
} 
