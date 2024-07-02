using Microsoft.SemanticKernel;
using System.ComponentModel;

namespace TerminalChatGPT.Plugins;
public class CryptoPlugin
{
  private IHttpClientFactory _httpClientFactory;
  public CryptoPlugin(IHttpClientFactory httpClientFactory)
  {
    _httpClientFactory = httpClientFactory;
  }
  [KernelFunction]
  [Description("Retrieves the current price of Bitcoin in EUR, GBP and USD")]
  public async Task<string> GetBitcoinInfo()
  {
    var httpClient = _httpClientFactory.CreateClient(nameof(CryptoPlugin));
    var bitcoinResponse = await httpClient.GetAsync("v1/bpi/currentprice.json");

    string bitcoinInfo = await bitcoinResponse.Content.ReadAsStringAsync();
    return bitcoinInfo;
  }
}
