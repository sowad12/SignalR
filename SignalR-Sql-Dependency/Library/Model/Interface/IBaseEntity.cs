namespace Library.Model.Interface
{
    public interface IBaseEntity:IEntity
    {
        void OnCreate();

        void OnUpdate();

        void OnDelete();
    }
}
