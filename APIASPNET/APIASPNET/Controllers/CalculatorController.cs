using Microsoft.AspNetCore.Mvc;

namespace APIASPNET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase{
      

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger){
            _logger = logger;
        }

        [HttpGet(Name = "sum/{firstNumber}/{secoundNumber}")]
        public IActionResult Get(string firstNumber, string secoundNumber) {
            if (IsNumeric(firstNumber) && IsNumeric(secoundNumber)) {
                var sum = ConnvertToDecimal(firstNumber) + ConnvertToDecimal(secoundNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }

        private decimal ConnvertToDecimal(string strNumber){
            decimal decimalValue;
            if (decimal.TryParse(strNumber, out decimalValue)) {
                return decimalValue;
            }
            return 0;
        }

        private bool IsNumeric(string strNumber){
            double number;

            bool isNumber = double.TryParse(
                strNumber, 
                System.Globalization.NumberStyles.Any, 
                System.Globalization.NumberFormatInfo.InvariantInfo, 
                out number);

            return isNumber;
        }
    }
}
