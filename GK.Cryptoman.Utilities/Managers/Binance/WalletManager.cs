using GK.Cryptoman.Model.Binance;
using System;
using System.Collections.Generic;
using System.Text;

namespace GK.Cryptoman.Utilities.Managers
{
    public class WalletManager : BinanceManagerBase
    {
        public WalletManager() : base()
        {
        }

        public Wallet_SystemStatusResponse SystemStatusWapi()
        {
            String url = String.Format("{0}?signature={1}",
                    "/wapi/v3/systemStatus.html",
                    this._signature);

            return this._client.Get<Wallet_SystemStatusResponse>(url, Configuration.Instance.Connections.BinanceAPI.UseProxy);
        }
        public Wallet_SystemStatusResponse SystemStatusSapi()
        {
            String url = String.Format("{0}?signature={1}",
                    "/sapi/v1/system/status",
                    this._signature);

            return this._client.Get<Wallet_SystemStatusResponse>(
                url, 
                Configuration.Instance.Connections.BinanceAPI.UseProxy);
        }

        public Wallet_GetAllCoinsResponse[] GetAllCoins(Wallet_GetAllCoinsParameters parameters)
        {
            String url = String.Format("{0}?signature={1}&recvWindow={2}&timestamp={3}",
                    "/sapi/v1/capital/config/getall",
                    this._signature,
                    parameters.RequestValidityWindow.TotalMilliseconds,
                    Convert.ToUnixTimestamp(parameters.TimeStamp));

            return this._client.Get<Wallet_GetAllCoinsResponse[]>(
                url, 
                Configuration.Instance.Connections.BinanceAPI.UseProxy);
        }
    }
}
