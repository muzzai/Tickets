namespace DiscountService.Core.DiscountAggregate.Rules;

public record DiscountResult(string Message, bool Success, decimal Amount);
