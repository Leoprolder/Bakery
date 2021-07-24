using Bakery.Core.Model.Enumerations;

namespace Bakery.Core.Model.Bun
{
    public static class BunBuilder
    {
        public static Bun Build(Bun bun)
        {
            switch (bun.BunType)
            {
                case BunType.Unknown:
                    break;
                case BunType.Baguette:
                    bun = new BaguetteBun(bun);
                    break;
                case BunType.Croissant:
                    bun = new CroissantBun(bun);
                    break;
                case BunType.Loaf:
                    bun = new LoafBun(bun);
                    break;
                case BunType.Pretzel:
                    bun = new PretzelBun(bun);
                    break;
                case BunType.SourCream:
                    bun = new SourCreamBun(bun);
                    break;
                default:
                    break;
            }

            return bun;
        }
    }
}
