using Core.Const;
using Core.Entity;
using DTO.Receipt;
using DTO.User;
using Microsoft.AspNetCore.Mvc;
using Services;
using WASA_DTOLib.Receipt;

namespace WASA_API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ReceiptController : ControllerBase
    {

        private readonly ReceiptService _receiptService;

        public ReceiptController(ReceiptService receiptService)
        {
            _receiptService = receiptService;
        }

        [HttpPost]
        public async Task<ReceiptEntity?> Add(AddReceiptRequest request)
        {
            if (ModelState.IsValid)
            {
                var receipt = await _receiptService.Add(request);
                return receipt;
            }
            return null;
        }

        [HttpPut]
        public async Task<ReceiptEntity?> Close([FromBody] GetReceiptByIdRequest request)
        {
            if (ModelState.IsValid)
            {
                return await _receiptService.Close(request);
            }
            return null;
        }

        [HttpPut]
        public async Task<ReceiptEntity?> Payment(PaymentReceiptRequest request)
        {
            if (ModelState.IsValid)
            {
                return await _receiptService.Payment(request);
            }
            return null;
        }

        [HttpPut]
        public async Task<ReceiptEntity?> Cancel(CancelReceiptRequest request)
        {
            if (ModelState.IsValid)
            {
                return await _receiptService.Cancel(request);
            }
            return null;
        }

        [HttpPut]
        public async Task<ReceiptEntity?> AddProducts(AddProductToReceiptRequest request)
        {
            if (ModelState.IsValid)
            {
                return await _receiptService.AddProducts(request);
            }
            return null;
        }

        [HttpPost]
        public async Task<ReceiptEntity?> ShowById(GetReceiptByIdRequest request)
        {
            if (ModelState.IsValid)
            {
                return await _receiptService.ShowById(request.Id);
            }
            return null;    
        }

        [HttpPost]
        public async Task<IEnumerable<ReceiptEntity>?> ShowCreatedByDate(ShowReceiptByDateRequest request)
        {
            if (ModelState.IsValid)
            {
                return await _receiptService.ShowCreatedByDate(request.Date!.Value);
            }
            return null;
        }

        [HttpPost]
        public async Task<IEnumerable<ReceiptEntity>?> ShowClosedByDate(ShowReceiptByDateRequest request)
        {
            if (ModelState.IsValid)
            {
                return await _receiptService.ShowClosedByDate(request.Date!.Value);
            }
            return null;
        }

        [HttpPost]
        public async Task<IEnumerable<ReceiptEntity>?> ShowPaymentByDate(ShowReceiptByDateRequest request)
        {
            if (ModelState.IsValid)
            {
                return await _receiptService.ShowPaymentByDate(request.Date!.Value);
            }
            return null;
        }
    }
}
