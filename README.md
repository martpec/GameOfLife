SOLID principles in this project

S- The classes were already set in the assignment, so each of them already mostly had a single responsibility.
I just separated Grid Creation from the Grid class into another class.

O- This is already achieved through the interface structure.

L- I would say there isn't much inheritance in this project to apply this principle.

I- Interfaces in this project are quite small and focused.

D- I achieved this through the IStorage interface. Although I use JSON for storing and loading into JSON files,
I designed the code so that you can create and use other classes which use or inherit 
the IStorage interface for loading and saving into different types of files.
