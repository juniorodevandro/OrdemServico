using MudBlazor;

namespace OrdemServico.Web.Extensions
{
    public static class StringExtensions
    {
        public static PatternMask ToCpfCnpjMask(this string value)
        {
            return value.Length > 11 ? new PatternMask("00.000.000/0000-00") : new PatternMask("000.000.000-00");
        }

        public static PatternMask ToPhoneMask(this string value)
        {
            return value.Length > 10 ? new PatternMask("(00) 0000-0000") : new PatternMask("(00) 00000-0000");
        }
    }
}
