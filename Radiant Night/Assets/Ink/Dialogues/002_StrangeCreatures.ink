=== CREATURES ===
Jacke! Where are you? #speaker:Charlie #portrait:Charlie_neutral
I’m right here, dude. What’s wrong? Why is she back? #speaker:Jacke #portrait:Jacke_neutral #next_waypoint:Jacke
I know it’s crazy, but she was really telling the truth!   #speaker:Charlie #portrait:Charlie_neutral
We just fought some big robot monster thing, I don’t even know what it was really.
She took the thing down, like she’s got magic powers or something!
Not quite magic, but- #speaker:Ashley #portrait:Ashley_neutral
Are you guys serious?  #speaker:Jacke #portrait:Jacke_neutral
Well I mean, of course you fought something, I can see that you guys are hurt, but magic powers? Weird monsters?
It’s more like tech enhancements than anything- #speaker:Ashley #portrait:Ashley_neutral
I saw it for myself, Jacke. All this stuff is real.  #speaker:Charlie #portrait:Charlie_neutral
I don’t know what that thing we fought was, and neither does she, but she is telling us the truth.
Wait, Ash, you don’t know what they are? #speaker:Jacke #portrait:Jacke_angry
(...Do I talk now...?) #speaker:Ashley #portrait:Ashley_angry
Sadly no, I assume they aren’t typical Earth creatures though, judging by Charlie’s reaction. #portrait:Ashley_neutral
They probably came to Earth just like I did, but that’s all I know, and even that is just an assumption.
Whoa… I have to see this for myself. Why don’t I come with you tomorrow and we’ll go hunt more of these things down? #speaker:Jacke #portrait:Jacke_happy
I’d love to have some help, thank you! #speaker:Ashley #portrait:Ashley_happy
Hey, hey, hold on guys… Jacke, I don’t know if I really want you going out there and causing trouble with these things. I don’t want you to get hurt.  #speaker:Charlie #portrait:Charlie_neutral
Ashley, I’ll come with you instead.
Are you serious?! I’m twenty years old! Don’t treat me like a baby, Char, I got this. #speaker:Jacke #portrait:Jacke_angry
No way, I need you to stay home and away from whatever those are, at least until we know more about what we’re dealing with. #speaker:Charlie #portrait:Charlie_angry
You think you’d be better in a fight than me, dude? #speaker:Jacke #portrait:Jacke_angry
That’s not at all what I’m saying, I just don’t want you to get into a fight at all! #speaker:Charlie #portrait:Charlie_angry
Why don’t you just let Ash decide then? Ashley, which of us would you wanna take with you to hunt down monsters? #speaker:Jacke #portrait:Jacke_angry
What?! Don’t let me pick, I just met you guys. #speaker:Ashley #portrait:Ashley_neutral
You don’t have to decide tonight. It’s getting late, how about we go in the morning? #speaker:Charlie #portrait:Charlie_angry
You mean we go in the morning, as in me and her. #speaker:Jacke #portrait:Jacke_angry
Regardless! Sounds like a good idea. I’m exhausted. #speaker:Ashley #portrait:Ashley_neutral
-> END
=== RAINSTORM ===
Hey. #speaker:Charlie #portrait:Charlie_neutral #next_waypoint:Charlie
Charlie? What are you doing awake? #speaker:Ashley #portrait:Ashley_neutral
I could ask you the same thing. I just couldn’t sleep, I assume it's the same for you? #speaker:Charlie #portrait:Charlie_neutral
I guess, but also… I’ve never seen a storm in person before. I've only heard about them as a child. It’s so strange, why does this happen? #speaker:Ashley #portrait:Ashley_neutral
It’s because the clouds in the sky get too full of water, and it all starts to fall out onto the world below. That’s us. #speaker:Charlie #portrait:Charlie_neutral
I can’t say I understand, but it is really pretty. #speaker:Ashley #portrait:Ashley_neutral
Yeah, I love the rain. Whether I’m in it or I’m just watching and listening to it, it’s got such a calming effect on me. #speaker:Charlie #portrait:Charlie_happy
I like to imagine that I can just let go of all the stressful stuff when it gets to be too much, kinda like the clouds do.
Hm… that, I can understand. #speaker:Ashley #portrait:Ashley_neutral
It’s why I couldn’t sleep, I think. I’m worried about the thing we saw out there today.  #speaker:Charlie #portrait:Charlie_neutral
I really don’t mean to be a jerk about protecting Jacke, I just want to keep them safe. Especially when we have no idea what these things are.
He seems like a tough kid, maybe you should give him a chance. #speaker:Ashley #portrait:Ashley_neutral
Do what you want, Ash, but if it’s up to me I just… can’t be okay with putting him in danger. #speaker:Charlie #portrait:Charlie_neutral
... #speaker:Ashley #portrait:Ashley_neutral
Thank you, again. For… believing me. And letting me stay here.
Of course! That’s what I do, I gotta make sure we all stay safe. Try and get some rest, okay? #speaker:Charlie #portrait:Charlie_happy
I will. You do the same, please. #speaker:Ashley #portrait:Ashley_happy
Hah, if you insist! #speaker:Charlie #portrait:Charlie_happy
-> END
=== DECISION ===
VAR teammate = ""
Good morning! Come sit, I made breakfast! #speaker:Charlie #portrait:Charlie_happy
Yeah, yeah, don’t be a kiss-up, Char. Let’s just get to the point. Which one of us are you taking with you today, Ash? #speaker:Jacke #portrait:Jacke_angry
Well... #speaker:Ashley #portrait:Ashley_neutral
* Jacke. #speaker:Ashley #portrait:Ashley_neutral
~ teammate = "Jacke"
What?! #speaker:Charlie #portrait:Charlie_angry
Wooo! That’s what I’m talking about, let’s do this! #speaker:Jacke #portrait:Jacke_happy
Ugh, fine… Just, promise me you guys will be careful, okay? #speaker:Charlie #portrait:Charlie_angry
Yeah, yeah, we will. #speaker:Jacke #portrait:Jacke_happy #follower:Jacke
-> END
* Charlie. #speaker:Ashley #portrait:Ashley_neutral
~ teammate = "Charlie"
Aw, what?! #speaker:Jacke #portrait:Jacke_angry
Phew… Thanks Ashley, you made the right decision. I promise, I won’t let you down! #speaker:Charlie #portrait:Charlie_happy #follower:Charlie
-> END
=== ADVENTURE ===
Alright, I think it might be a good start to ask other people if they’ve seen any of these things. We can get a good idea of the scope of this issue. #speaker:Ashley #portrait:Ashley_neutral
{
- teammate == "Jacke": Sounds good to me. #speaker:Jacke #portrait:Jacke_neutral
-> END
- else: Good idea, let’s get moving! #speaker:Charlie #portrait:Charlie_neutral
-> END
} 
=== SHOPINTRO ===
Welcome to my little shop, young lady. How can I help you? #speaker:Shopkeeper #portrait:Shopkeeper_happy
We’re wondering if you’ve seen anything strange lately. Spot any strange creatures roaming around last night? #speaker:Ashley #portrait:Ashley_neutral
What do you know about them? #speaker:Shopkeeper #portrait:Shopkeeper_neutral
So you have seen one? #speaker:{teammate} #portrait:{teammate}_neutral
One? I saw a whole slew of those things wandering around in the forest behind my ranch. #speaker:Shopkeeper #portrait:Shopkeeper_neutral
I got almost no sleep last night because I was worried that whatever they were, they’d be a threat to my animals and my crops.
I can’t afford to be losing out on perfectly good products just because some weird pests wanna get a taste for free!
{
- teammate == "Charlie": Hey Ashley, a quick word?  #speaker:Charlie #portrait:Charlie_neutral
What is it? #speaker:Ashley #portrait:Ashley_neutral
Maybe we should ask this guy to bring us to his ranch and see what we can find there. What do you think? #speaker:Charlie #portrait:Charlie_neutral
Sounds like as good a lead as any. #speaker:Ashley #portrait:Ashley_happy
Why don’t you let us take a look for you? Maybe we can get them to leave the ranch alone!
- else: We’d be happy to take that problem off your hands for a good discount. #speaker:Jacke #portrait:Jacke_happy
} 
Oh! Are you two some kind of extermination service? I’d be happy to show you to my ranch so you can fend off the unwanted vermin.  #speaker:Shopkeeper #portrait:Shopkeeper_happy
Wasn’t too thrilled about heading out to the shop today anyways… I’m worried about my little beauties! #portrait:Shopkeeper_neutral
I’ll be happy to pay you for helping me out. Come with me, we’ll head there now. #portrait:Shopkeeper_happy
-> END
=== TOWN_A ===
Do I know you? #speaker:??? #portrait:Extra1_neutral
Have you seen any strange creatures recently? #speaker:Ashley #portrait:Ashley_neutral
Um… No? Unless you count rats, I’ve seen tons of those in that alley over there. They ain’t that strange though, mostly just nasty. #speaker:??? #portrait:Extra1_neutral
-> END
=== TOWN_B ===
Can I help you? #speaker:??? #portrait:Richie_neutral
I was wondering if you’ve heard of any strange sightings of monsters recently. #speaker:Ashley #portrait:Ashley_neutral
I can’t say I have. Honestly I feel like the city’s too noisy to hear anything other than cars honking and people yelling all the time.  #speaker:??? #portrait:Richie_neutral
Maybe at night there was a bit more hustle and bustle than usual, but I certainly didn’t see anything weird.
-> END
=== TOWN_C ===
What? #speaker:??? #portrait:Extra3_neutral
Seen anything unusual lately? Like a strange monster of some kind? #speaker:Ashley #portrait:Ashley_neutral
You mean besides you? #speaker:??? #portrait:Extra3_neutral
-> END
=== RANCH ===
Here we are! Feel free to take a look around, just be careful, alright? Don’t want any harm coming to my crops or my sweet animals. #speaker:Shopkeeper #portrait:Shopkeeper_neutral
I saw those things you were talking about coming from the forest over there. Think you could start there, see what you can spot? #portrait:Shopkeeper_neutral
We’re on it! #speaker:Ashley #portrait:Ashley_happy
-> END
=== ENCOUNTER ===
{
- teammate == "Charlie": -> ENCOUNTER_C
- else -> ENCOUNTER_J
} 
=== ENCOUNTER_C ===
Jacke, no! Crap, I never wanted this to happen… we’ve gotta save them! #speaker:Charlie #portrait:Charlie_angry
We’ve done it before and we’ll do it again, let’s do this! #speaker:Ashley #portrait:Ashley_angry
-> END
=== ENCOUNTER_J ===
Oh my god, those things are freaky! We gotta help Charlie! #speaker:Jacke #portrait:Jacke_angry
Don’t worry, we’ve got this. Just follow my lead, Jacke! #speaker:Ashley #portrait:Ashley_angry
-> END
=== POSTFIGHT ===
{
- teammate == "Charlie": -> POSTFIGHT_C
- else -> POSTFIGHT_J
} 
=== POSTFIGHT_C ===
Jacke! Are you okay? I’m so sorry- #speaker:Charlie #portrait:Charlie_neutral
Charlie, I’m fine. I had it handled! #speaker:Jacke #portrait:Jacke_angry
I mean, it kinda didn’t seem like it… #speaker:Ashley #portrait:Ashley_neutral
This is why I didn’t want you coming along with us, you’re gonna get hurt! #speaker:Charlie #portrait:Charlie_angry
Are you blaming me for getting jumped by a freaky alien robot? #speaker:Jacke #portrait:Jacke_angry
I mean, again, not quite alien- #speaker:Ashley #portrait:Ashley_angry
You could have just stayed at home! I can’t be in two places at once, I needed to help Ashley. #speaker:Charlie #portrait:Charlie_angry
I didn’t ask for your protection! So what, I got caught off guard by something unlike anything I’ve ever seen before, and that makes me helpless? #speaker:Jacke #portrait:Jacke_angry
To be fair, Jacke was a big help near the end of that fight, maybe we oughta give them more credit. #speaker:Ashley #portrait:Ashley_neutral
Thank you, Ash… You gotta stop treating me like I’m a baby, Char. Whatever’s been going on is weird, yeah, but I wanna be a part of this. #speaker:Jacke #portrait:Jacke_angry
Don’t leave me out of it like I’m some little kid. I can protect myself and you just fine.
Jacke’s right. We made it out of there because we all worked together! I know you both want to protect each other, but aren’t we better as a unit? #speaker:Ashley #portrait:Ashley_neutral
You know what? You’re right. I’ve been kind of a jerk, that’s on me.  #speaker:Charlie #portrait:Charlie_angry
We’ll all be safer in the long run if we stick together, so that seems like the best choice to me. #portrait:Charlie_neutral
Yes!! Let’s do some robot hunting!! #speaker:Jacke #portrait:Jacke_happy
For now, we should go collect that reward the shopkeeper offered us, now that we stopped the robots from attacking his farm. #speaker:Charlie #portrait:Charlie_happy
Reward? And I’ll get a cut of that, right? After all, I did, uhh, help you find them? #speaker:Jacke #portrait:Jacke_happy
We’re a team now! You’re all in, Jacke. Let’s get moving! #speaker:Ashley #portrait:Ashley_happy #follower:Jacke
-> END
=== POSTFIGHT_J ===
Guys… Thank you for saving me. Jacke, I think you should head home. It’s getting real dicey out here. Ashley and I can handle this from here. #speaker:Charlie #portrait:Charlie_neutral
Are you serious? I just saved your butt, dude. #speaker:Jacke #portrait:Jacke_angry
* We did it together, all three of us. I think we all deserve to take some credit.
* Charlie, I think you oughta give Jacke a little more credit. 
I couldn’t have done it without him, after all.
- But I… Oh alright, I can admit when I’m wrong… You did really great out there, Jacke. #speaker:Charlie #portrait:Charlie_angry
I’m sorry I didn’t have faith in you, I just didn’t want you to get involved in all this dangerous alien stuff. #portrait:Charlie_neutral
I mean, again, not alien- #speaker:Ashley #portrait:Ashley_angry
You gotta remember that I’m not a kid anymore, Char. Whatever’s been going on is weird, yeah, but I wanna be a part of this. #speaker:Jacke #portrait:Jacke_neutral
Don’t leave me out of it like I’m some little kid. I can protect myself and you just fine.
Let’s not forget which of us was just in the jaws of some creepy robot monster… #portrait:Jacke_angry
Jacke’s right. We made it out of there because we all worked together! I know you both want to protect each other, but aren’t we better as a unit? #speaker:Ashley #portrait:Ashley_neutral
You know what? You’re right. I’ve been kind of a jerk, that’s on me.  #speaker:Charlie #portrait:Charlie_angry
We’ll all be safer in the long run if we stick together, so that seems like the best choice to me. #portrait:Charlie_neutral
Glad you came around, man. Now what'd you say we go collect that sweet reward from that ranch guy? #speaker:Jacke #portrait:Jacke_happy
Let’s do it, team! #speaker:Ashley #portrait:Ashley_happy #follower:Charlie
-> END
=== QUEST_END ===
Oh! Is everything taken care of back there? #speaker:Shopkeeper #portrait:Shopkeeper_happy
Yes sir, you should be safe for the time being. #speaker:Ashley #portrait:Ashley_happy
Thank you all, kindly. Here, take this as a thank you. Now I know just who to call when these monsters are givin’ me trouble! #speaker:Shopkeeper #portrait:Shopkeeper_happy
You just let us know, sir. We’re happy to help! #speaker:Charlie #portrait:Charlie_happy
Yeah, you keep prizes like this coming and I’ll take out robots in the forest for you anytime. #speaker:Jacke #portrait:Jacke_happy #quest_add:Q006 #reward:Q002
For sure! You all just head back home, now. I should be all set here for now! #speaker:Shopkeeper #portrait:Shopkeeper_happy
And be sure to stop by my shop anytime, my friends! Be safe on your journeys!
-> END
=== BACK_HOME ===
What. A. Day. I need a nap. #speaker:Jacke #portrait:Jacke_neutral
Today's definitely been a lot. We'll sleep good tonight, I'm sure. #speaker:Charlie #portrait:Charlie_neutral
What's going to happen now? Should we go out again tomorrow to find more monsters? #speaker:Ashley #portrait:Ashley_neutral
Well I know I can't, I have work all day tomorrow. #speaker:Charlie #portrait:Charlie_neutral
Ugh, and I have classes in the morning. Why'd ya have to remind me? #speaker:Jacke #portrait:Jacke_angry
Wait, you guys are both busy? I'll have to go back out there myself... #speaker:Ashley #portrait:Ashley_neutral
Or... You could take a break. You probably need it, Ash. You've been nonstop since you got here. #speaker:Jacke #portrait:Jacke_happy
I'm actually with Jacke on this one. The world isn't gonna fall apart in one day. If you want, you could come to work with me! #speaker:Charlie #portrait:Charlie_happy
That way you can have a little change of scenery and think about Earth things besides protecting it from scary robots. #quest_add:Q004
I don't know... #speaker:Ashley #portrait:Ashley_angry
If you aren't feeling Charlie's boring diner, you can come sit in on my classes with me. #speaker:Jacke #portrait:Jacke_happy
You into engineering? I mean, you are a robot alien girl.
Can you stop calling me that?? #speaker:Ashley #portrait:Ashley_angry
I'm kidding! You know what I mean. It could be fuuuun! #speaker:Jacke #portrait:Jacke_happy #quest_add:Q005
It's up to you at the end of the day, Ashley. If you wanna head into the forest again, go for it. #speaker:Charlie #portrait:Charlie_neutral
But our offers are there if you want to see what else Earth has in store for you! #portrait:Charlie_happy
I'll think about it, thanks guys. #speaker:Ashley #portrait:Ashley_happy #quest_add:Q003
-> END