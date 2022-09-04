# Game Event System
The ScriptableObject Game Event has a List of Game Event Listeners that registered to the Game Event with public methods to register and unregister. When the Event is Raised it notifies all of the registered listeners and tells them to run their code.


![Game Events](/Assets/Graphics/Images/GameEvents.jpg)

For Example,

We give the events we created as a reference to the component. Then invoke that Event wherever we want.

We use Game Event Listener to add a method to that Event.
