using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PointOfSale.Business.Contracts;
using PointOfSale.Models;
using PointOfSale.Utilities.Logger;

namespace PointOfSale.Controllers
{
    public class TemplateController : Controller
    {
        private readonly ISaleService _saleService;
        private readonly IGatePassService _gatePassService;
        private readonly IMapper _mapper;
        Loggers log = new Loggers();
        public TemplateController(ISaleService saleService, IMapper mapper, IGatePassService gatePassService)
        {
            _saleService = saleService;
            _mapper = mapper;
            _gatePassService = gatePassService;
        }
        public async Task<IActionResult> PDFSale(string saleNumber)
        {
            VMSale vmVenta = _mapper.Map<VMSale>(await _saleService.Detail(saleNumber));

            return View(vmVenta);
        }

        public async Task<IActionResult> PDFGatePass(int recordID)
        {
            try
            {
                log.LogWriter("PDFGatePass");
                VMGatePass vmVenta = _mapper.Map<VMGatePass>(await _gatePassService.GetSingle(recordID));
                return View(vmVenta);
            }
            catch (Exception ex)
            {
                log.LogWriter("PDFGatePass Exception: " + ex);
                throw;
            }

        }
    }
}
