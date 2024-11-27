public interface UIButton
{
    bool IsPressed { get; set; }
    void ButtonDown();
    void ButtonUp();
}