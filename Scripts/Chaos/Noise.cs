using UnityEngine.Playables;

namespace Claw.Chaos {
    public static class Noise {

        private const uint BIT_NOISE1 = 0xB5297A4D;
        private const uint BIT_NOISE2 = 0x68E31DA4;
        private const uint BIT_NOISE3 = 0x1B56C4E9;

        // Used to generating multi-dimensional noise
        private const int PRIME_NUMBER_1 = 198491317;
        private const int PRIME_NUMBER_2 = 198491317;
        
        
        public static uint Get1dUint(int pos, uint seed = 0) {

            uint mangled = (uint)pos;
            mangled *= BIT_NOISE1;
            mangled += seed;
            mangled ^= (mangled >> 8);
            mangled += BIT_NOISE2;
            mangled ^= (mangled << 8);
            mangled *= BIT_NOISE3;
            mangled ^= (mangled >> 8);
            return mangled;
        }

        public static uint Get2dUint(int posX, int posY, uint seed = 0) {

            return Get1dUint(posX + (PRIME_NUMBER_1 * posY), seed);
        }

        public static uint Get3dUint(int posX, int posY, int posZ, uint seed) {

            return Get1dUint(posX + (PRIME_NUMBER_1 * posY) + (PRIME_NUMBER_2 * posZ), seed);
        }

        
        public static float Get1dZeroToOne(int pos, uint seed = 0) {
            
            return UintToZeroToOne(Get1dUint(pos, seed));
        }
        
        public static float Get2dZeroToOne(int posX, int posY, uint seed = 0) {
            
            return UintToZeroToOne(Get2dUint(posX, posY, seed));
        }
        
        public static float Get3DZeroToOne(int posX, int posY, int posZ, uint seed = 0) {
            
            return UintToZeroToOne(Get3dUint(posX, posY, posZ, seed));
        }
        

        public static float Get1dNegOneToOne(int pos, uint seed = 0) {

            return UintToNegOneToOne(Get1dUint(pos, seed));
        }

        public static float Get2dNegOneToOne(int posX, int posY, uint seed = 0) {

            return UintToNegOneToOne(Get2dUint(posX, posY, seed));
        }

        public static float Get3dNegOneToOne(int posX, int posY, int posZ, uint seed = 0) {

            return UintToNegOneToOne(Get3dUint(posX, posY, posZ, seed));
        }


        private static float UintToZeroToOne(uint val) {
            return ((float)val / uint.MaxValue);
        }

        private static float UintToNegOneToOne(uint val) {
            long res = val;
            res -= uint.MaxValue / 2;

            return ((float) res / uint.MaxValue / 2);
        }
    }
}