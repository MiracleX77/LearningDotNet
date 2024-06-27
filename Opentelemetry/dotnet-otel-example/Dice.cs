using System.Diagnostics;

public class Dice{

    private ActivitySource activitySource;
    private int min;
    private int max;

    public Dice(int min, int max, ActivitySource activitySource){
        this.min = min;
        this.max = max;
        this.activitySource = activitySource;
    }

    public List<int> rollTheDice(int times){
        List<int> results = new List<int>();
        Random random = new Random();

        using (var activity = activitySource.StartActivity("rollTheDiceeeeeeee"))
        {
            activity?.AddEvent(new("Init"));


            for (int i = 0; i < times; i++)
            {
                results.Add(rollOnce());
            }
            activity?.AddEvent(new("End"));

        }
        return results;
    }

    private int rollOnce(){
        using (var childActivity = activitySource.StartActivity("rollOnce"))
        {
            int result;
            result = Random.Shared.Next(min, max + 1);
            childActivity?.SetTag("dicelib.rolled", result);

            //Add Event to the Activity
            childActivity?.AddEvent(new("Rolled Dice", DateTimeOffset.Now, new ActivityTagsCollection { { "result", result } }));

            return result;
        }
    }
}