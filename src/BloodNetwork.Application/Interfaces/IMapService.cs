namespace BloodNetwork.Application.Interfaces;

public interface IMapService
{
    double CalculateDistanceKm(double lat1, double lon1, double lat2, double lon2);
    Task<(double Latitude, double Longitude)?> GeocodeAsync(string address);
}
