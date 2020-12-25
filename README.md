# nCroner.Common
You can use this package to create plugins for nCroner. Project type must be .Net Standard 2.1 or higher

# Installing via NuGet
  
    Install-Package nCroner.Common

## Getting Started
Everything starts with an event. When an event occurs and is executed, a series of output values are returned. These values can be the input of one middleware and the output of the middleware of another input until finally the input of an operation and this event ends.

Everything is based on existing plugins and JSON files that describe the procedure.

Sample:
1. At 8 o'clock in the morning Iranian time
2. Receive the weather condition of Tehran
3. To send to a specific telegram channel (in which a bot has already been added as an admin) along with meteorological descriptions and meteorological photos

JSON:

    {
      "Id": "47995a88-469b-4417-a724-756c3fcf1676",
      "Title": "Send today weather on 08:00 AM to telegram channel",
      "Enabled": true,

      "Event": {
        "CollectionId": "6a7bf411-3b75-4c32-9350-4b860a0df611",
        "Id": "6721b5e4-31f3-41c2-acde-56b3c2b2c203",
        "Input": {
          "OnTime": "08:00",
          "TimeZone": "Iran Standard Time" 
        }
      },

      "MiddleWares": [
        {
          "Id": "7e4dc2c5-ac80-44b4-ac1c-7ddfe0349f57",
          "Input": {
            "APIKey": "11122222333344445555 (openweathermap.org API key)",
            "City": "Tehran,ir",
            "TimeZone": "Iran Standard Time"
          }
        }
      ],

      "Operation": {
        "CollectionId": "d4f59b2f-df0b-435d-9924-30d2e6cb413b",
        "Id": "4b163822-7048-4cb2-98ee-05045871c02a",
        "Input": {
          "ImageUrl": "http://openweathermap.org/img/wn/{Icon}@2x.png",
          "Format": "<b>{CityName}:</b> {Description}\nCurrent Temp: {Temp}\nMin Temp: {MinTemp}\nMax Temp: {MaxTemp}\nSunrise: {Sunrise}\nSunset: {Sunset}",
          "Channel": "@ChannelName",
          "BotToken": "1111111:222222AAAAABBBBBCCCCC (Bot Token)"
        }
      }
    }
   

## Event
* EventCollection
  Includes information about the set of events within the plugins as well as the introduction of events
  
      public abstract Guid Id { get; }
      public abstract string Title { get; }
      public abstract int Interval { get; }
      public virtual void Init(IServiceCollection services)
      protected void AddEvent<T>(Guid id, string title, string eventRoute = "")
      
* IEvent
  The event is defined in this section. The inputs defined in the settings file are sent to the input of this DoWork method to get started
  
      Task<EventResponse> DoWork(Guid id, IDictionary<string, object> input);
  

## Middleware
* MiddlewareCollection
  Middleware programs that are supposed to make changes to the output and create a new output
  
      public virtual void Init(IServiceCollection services)
      protected void AddMiddleware<T>(Guid id, string title)

* IMiddleware
  The middle of the program is defined in this section. The outputs of the previous step are input to this section.
  
      Task<EventResponse> DoWork(Guid id, IDictionary<string, object> input);
      
## Operation
* OperationCollection
  Includes information about the set of operations as well as the introduction of events
  
      public abstract Guid Id { get; }
      public abstract string Title { get; }
      public virtual void Init(IServiceCollection services)
      protected void AddOperation<T>(Guid id, string title)

* IOperation
  The final operation is done through operation. Previous outputs are entered in this section and the desired operation is performed.
  
      Task DoWork(Guid id, IDictionary<string, object> input);

## Tools
* IDb:

  The events database is LiteDb. To use inject **IDb** and call the following method to access the database
    ```
    var col = _db.GetCollection<FeedItemEntity>(id, "Test");
    ```

* ITaskRunner:

  Inject **ITaskRunner** to run a Task in the background
    ```
    void Add(Action action);
    ```
    
