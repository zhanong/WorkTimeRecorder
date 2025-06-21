Tired of manually starting and stopping your time tracker? Frustrated when you forget to toggle it on or off?

This is the app for you. It's a lightweight, silent utility that automatically records your work time, guaranteeing you an uninterrupted and immersive work experience.

### How It Works

The timer continuously checks for your activity, such as mouse clicks and keystrokes. If no activity is detected, a 10-minute countdown begins. This countdown will be cancelled as soon as any action is registered. If the countdown completes, the app pauses the work time recording until you resume your activity.

To ensure that only relevant work is tracked, the app also checks the title of the currently active window. If you switch to a window that isn't on your designated "work window" list, the countdown will start, even if you are actively clicking or typing. You have complete control over what constitutes a "work window."

### How to Use It

1. Click **Set Keywords** to define your "work windows."
    
2. In the **Set Keywords** window, enter the terms that identify your work-related applications. The app checks each line as a separate rule. If the active window's title contains **all the words in a single line**, it is considered a "work window."
    
    - For example, with the keywords shown above, a window named "Work Time Recorder" would be tracked, but a window named "Davinci's Work" would not.
3. Use the **+ 30 min** and **- 30 min** buttons to manually adjust your recorded work time as needed.
    

The **Week Average** displays your average daily work time for the current week (Monday to Sunday). This is calculated by dividing the total weekly hours by the number of days in the week that have passed. Time worked on weekends will contribute to your weekly average.

### Technical Details

The app automatically creates a `TimeData` folder in its directory to store your data and keywords in the following files:

```
DayData.txt
WeekData.txt
KeyWord.txt
```

This application uses system hooks to monitor mouse and keyboard activity.