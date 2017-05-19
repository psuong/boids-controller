# Boids Controller

This repo is an implementation of flocking. Source code is provided, but not all assets can be provided.
These assets will not be provided as I do not have privilege to distribute them, however they are all free
to acquire from the Unity Asset Store.

The assets **do not** have any effect on the *flocking algorithm* at all and are mainly used for visual aids.

## IMPORTANT
If you are not used to the Unity interface - then jump to the [Releases](https://github.com/psuong/boids-controller/releases) tab.

# Assets 
All assets mentioned are free and are simply for visual aids. They have no fundamental affect on the flocking algorithm.
* TextMeshPro
* ProBuilder Basic

# Project Structure
You must have **Unity 5.6** installed to run the demo if you intend to clone the demo!

If things appear to be missing - please get the above aforementioned Assets above!
```
Assets                              # Root directory
├───Editor                          # Shows debugging options in the scene view
├───Materials                       # Materials used for colour
├───Models                          # Models used (just the triangular bot)
├───Prefabs                         # Templates
├───Scenes                          # Where the demo lives
│   ├───Boid_Controller             # Simple boid controller example
│   └───Boid_Controller_Obstacle    # Simple boid controller example with obstacles
└───Scripts                         # Scripts for the GUI and the BoidController
```

# Releases
Please check the [Releases](https://github.com/psuong/boids-controller/releases) tab found on Github for the built projects. **Built projects** are specifically compiled for **Windows**. A **Linux** version will eventually be built. **OSX** will *not* be supported because I do not have an OSX machine.