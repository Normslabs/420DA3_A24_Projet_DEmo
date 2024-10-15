﻿using Project_Utilities.Enums;
using Project_Utilities.Services.APIs;

namespace Project_Utilities.Services;
public class TrackingNumberFactory {

    private static readonly FakeCanadaPostAPI fakeCanadaPostAPI = new FakeCanadaPostAPI();
    private static readonly FakeFedExAPI fakeFedExAPI = new FakeFedExAPI();
    private static readonly FakePurolatorAPI fakePurolatorAPI = new FakePurolatorAPI();


    public static string GetNewTrackingNumber(ShippingProvidersEnum shipmentProvider) {
        string trackingNumber;
        switch (shipmentProvider) {
            case ShippingProvidersEnum.Purolator:
                trackingNumber = fakePurolatorAPI.GetTrackingNumber();
                break;
            case ShippingProvidersEnum.FedEx:
                trackingNumber = fakeFedExAPI.GetTrackingNumber();
                break;
            case ShippingProvidersEnum.PostesCanada:
            default:
                trackingNumber = fakeCanadaPostAPI.GetTrackingNumber();
                break;

        }
        return trackingNumber;
    }
}
