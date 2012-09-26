using System;

namespace Meston
{
    /// <summary>
    /// http://en.wikipedia.org/wiki/Haversine_formula
    /// </summary>
    public class Haversine
    {
        private const float HAVERSINE_RADS_PER_DEGREE = 0.0174532925199433f;
        private const float HAVERSINE_MI_RADIUS = 3956.0f;
        private const float HAVERSINE_KM_RADIUS = 6371.0f;
        private const float HAVERSINE_M_PER_KM = 1000.0f;
        private const float HAVERSINE_F_PER_MI = 5282.0f;

        private float lat1;
        private float lon1;
        private float lat2;
        private float lon2;

        public Haversine(float newLat1, float newLon1, float newLat2, float newLon2)
        {
            this.lat1 = newLat1;
            this.lon1 = newLon1;
            this.lat2 = newLat2;
            this.lon2 = newLon2;
        }

        public double Distance()
        {
            double lat1Rad;
            double lat2Rad;
            double dLonRad;
            double dLatRad;
            double a;

            lat1Rad = lat1 * HAVERSINE_RADS_PER_DEGREE;
            lat2Rad = lat2 * HAVERSINE_RADS_PER_DEGREE;
            dLonRad = ((lon2 - lon1) * HAVERSINE_RADS_PER_DEGREE);
            dLatRad = ((lat2 - lat1) * HAVERSINE_RADS_PER_DEGREE);

            a = Math.Pow(Math.Sin(dLatRad / 2), 2) + Math.Cos(lat1Rad) * Math.Cos(lat2Rad) * Math.Pow(Math.Sin(dLonRad / 2), 2);
            return (2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a)));
        }

        public double ToKilometers()
        {
            return Distance() * HAVERSINE_KM_RADIUS;
        }

        public double ToMeters()
        {
            return ToKilometers() * HAVERSINE_M_PER_KM;
        }

        public double ToMiles()
        {
            return Distance() * HAVERSINE_MI_RADIUS;
        }

        public double ToFeet()
        {
            return ToMiles() * HAVERSINE_F_PER_MI;
        }
    }
}
