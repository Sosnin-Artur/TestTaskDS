namespace Animals.Spawner.Model
{
    public interface ISpawnerInitData : IModel
    {
        public float MinCooldown { get; }
        public float MaxCooldown { get; }
        public float SpawnRadious { get; }
    }
}