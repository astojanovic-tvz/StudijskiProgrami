namespace HKOWebMVC4.Models.HKOWebModels.AjaxModels
{
    public class _AjaxResponseModel
    {
        public _AjaxResponseModel() { type = AjaxResponseType.OK; }

        public AjaxResponseType type { get; set; }
        public string message { get; set; }
    }

    public enum AjaxResponseType
    {
        OK , Error , Warning
    }
}