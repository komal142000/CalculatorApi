using Microsoft.AspNetCore.Mvc;
using CalculatorApi.Models;
using CalculatorApi.Services;

namespace CalculatorApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CalculatorController : ControllerBase
{
    [HttpPost("evaluate")]
    public ActionResult<EvaluateResponse> Evaluate(
        EvaluateRequest request)
    {
        var result =
            ExpressionEvaluator.Evaluate(
                request.Expression);

        return Ok(new EvaluateResponse
        {
            Result = result
        });
    }
}