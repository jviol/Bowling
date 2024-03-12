An interactive CLI application that works as a Bowling Scoreboard for a single player.

### Design Choices
I have tried as far as possible to keep the logic of the game under the 'model' directory, 
so that the command line interface can theoretically be replaced with a GUI or a web interface.
This also makes the code more testable.

In practice, this means the Game object expects to be passed a number of rolls until it is complete. 

Note that there still is some logic in the CLI, so that it is possible to tell which frame is being played.

I have decided to implement the bonus rolls for the 10th frame as extra frames, 
rather than extra rolls in the 10th frame. This is in order to streamline the frame logic, 
i.e. the 10th frame is scored in the same way as the other frames, and we just don't score the bonus frames.

