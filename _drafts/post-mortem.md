# LD34 Post Mortem

_by Robbie Cooper_

[Link to game](http://ludumdare.com/compo/ludum-dare-34/?uid=58187)

## Things Done Well

### Creative Freedom

We were free to suggest ideas without aversion to criticism. We were free to criticize ideas.

Giving ideas a chance that I didn't agree with tended to turn out well. Concrete example: The on-screen buttons. I thought they'd look tacky and minimal ones would be sufficient. Ultimately, they were nice to have and their presence hammered home the idea of a two-button game. 

### Dedicated Artist

Having Darren made things so much better. He had funny ideas that we wouldn't have had otherwise. He added details to our requests that gave the characters and scenery personality. We wouldn't have thought of them ourselves. It's good that he took the freedom to do that. It's a thing I will encourage artists to do in future projects.

Darren also saved us a lot of time. Good art (or any art) takes time to crank out. We would not have nearly as many assets if we had to both code and make art.

### Reuse

We were able to reuse a lot of elements of our game in order to wrap it up without much work.

We created a MinigameManager and MinigameBehavior to make adding minigames easier. With that, we could easily add new parts to the game, making our scope flexible. If we planned using small chunks of gameplay (minigames), we could easily get things accomplished. This way, we could keep chaining minigames until the deadline.

Since our minigame architecture did everything within a single Unity "scene", we didn't have to worry about transferring data between minigames; all data was loaded all the time. We took advantage of this when we separated the main beanstalk scenery from the minigames so that we could reuse it for the falling; it was shared among minigames.

We reused the second half of our game. The winning and losing outcomes were basically the same, but both satisfying. All we did was change the dunked sprite to a baby or trashbag depending on whether the player completed the stealth minigame successfully. Both conclusions were satisfying and plausible and seemed like they were a consequence of the player's actions. Only on replaying the game could the player learn how similar the endings were.

Speaking of replay value, we essentially doubled the replay value by having two endings, despite only coding gameplay for one.

I think it was a good thing that we didn't have a true losing state. We wanted people to be able to experience the whole game without problems. For a narrative game, this makes a lot of sense. There's no enjoyment from re-experiencing the same narrative (which is something that traditionally happens on game-over). The exception is if knowing later narrative affects the interpretation of earlier narrative.

## Things that could have been better

More trash. We could have arranged to have more trash art from Darren. Easier said than done though since his schedule wasn't reliable. I'm grateful that he did end up putting a lot of time into the project despite his schedule.

More music. Though we had a musician, he wasn't full-time, so we only got one track of music by the deadline. Like an artist, a dedicated musician really helps to polish a game on time. (Though I'm still under the impression that they're easier to replace, but maybe that opinion would change if we had one.)

We could have made an ending for when the player doesn't charge their throw. The would eliminate negative possibility space. 

## Things Learned (technical)

- Unity
- Practice with entity-component
- Audacity basics
