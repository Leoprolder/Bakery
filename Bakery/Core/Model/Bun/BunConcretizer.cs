namespace Bakery.Core.Model.Bun
{
    public static class BunConcretizer
    {
        public static Bun Concretize(Bun bun)
        {
            switch (bun.BunType)
            {
                case Enumerations.BunType.Unknown:
                    break;
                case Enumerations.BunType.Baguette:
                    bun = new BaguetteBun(bun);
                    break;
                case Enumerations.BunType.Croissant:
                    bun = new CroissantBun(bun);
                    break;
                case Enumerations.BunType.Loaf:
                    bun = new LoafBun(bun);
                    break;
                case Enumerations.BunType.Pretzel:
                    bun = new PretzelBun(bun);
                    break;
                case Enumerations.BunType.SourCream:
                    bun = new SourCreamBun(bun);
                    break;
                default:
                    break;
            }

            return bun;
        }
    }
}
