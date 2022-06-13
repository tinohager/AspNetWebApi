namespace BodyRequestValidation.Dtos
{
    public class PagingInfoDto<T>
    {
        public int Total { get; set; }
        public T[] Items { get; set; }
    }
}
