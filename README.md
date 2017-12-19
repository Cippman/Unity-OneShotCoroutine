# Unity-OneShotCoroutine
OneShotCoroutine

Notes: 
1) I'm not sure how much OneShotCoroutine costs on performances, but at least to implement fast-behaviour logics (prototyping or similar cases) it is really useful.
2)  Const properties inside of OneShotCoroutine should be edited manually to see effects.

Example Usage: 
1) you need a gameobject that active and deactivate itselft each tot time,  but you don't want to create an external reference because unity doesn't play coroutines on gameObjects that are inactive? Done.
2) You'd like to ''invoke'' an action after a specific amount of time? Done.