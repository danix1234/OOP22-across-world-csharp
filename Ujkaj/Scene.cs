public interface Scene
{
    Panel GetPanel();

    void Update();

    InputHandler GetInputHandler(SceneType sceneType);
}