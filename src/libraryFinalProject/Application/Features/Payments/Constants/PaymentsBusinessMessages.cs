namespace Application.Features.Payments.Constants;

public static class PaymentsBusinessMessages
{
    public const string SectionName = "Payments";

    public const string PaymentNotExists = "PaymentNotExists";
    public const string InvalidOrder = "Geçersiz sipariþ."; // hata mesajý tanýmý
    public const string PaymentAmountMustBe = "Payment amount must be greater than zero";
}