public interface IWorkingTime{
    public string Time {get;}
    bool IsDayEnded {get;}

    void StartNewDay();
}
