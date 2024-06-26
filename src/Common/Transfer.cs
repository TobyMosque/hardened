using Neo;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services;
using System;
using System.Numerics;
using static Hardened.Helpers;


namespace Hardened
{
  public class Transfer
  {
#pragma warning disable CS8625 // Suppress known warning
    private const string TRANSFER_METHOD = "transfer";
    private const string NEP11_TRANSFER_FAILED = "NEP11 transfer failed";
    private const string NEP17_TRANSFER_FAILED = "NEP17 transfer failed";

    public static void Safe11Transfer(UInt160 contractHash, UInt160 to, ByteString tokenId)
    {
      try
      {
        bool result = (bool)Contract.Call(contractHash, TRANSFER_METHOD, CallFlags.All, new object[] { to, tokenId, null });
        Assert(result, NEP11_TRANSFER_FAILED);
      }
      catch (Exception)
      {
        Assert(false, NEP11_TRANSFER_FAILED);
      }
    }

    public static void Safe17Transfer(UInt160 contractHash, UInt160 from, UInt160 to, BigInteger amount)
    {
      try
      {
        var result = (bool)Contract.Call(contractHash, TRANSFER_METHOD, CallFlags.All, new object[] { from, to, amount, null });
        Assert(result, NEP17_TRANSFER_FAILED);
      }
      catch (Exception)
      {
        Assert(false, NEP17_TRANSFER_FAILED);
      }
    }
#pragma warning restore CS8625 // Suppress known warning
  }
}