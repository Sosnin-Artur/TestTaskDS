using Animals.Spawner.Model;

namespace Animals.Spawner.View
{
    public interface ISpawnerView : IView
    {
        void SetUp(ISpawnerData data);
    }
}