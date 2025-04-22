CONST playerName = "Ashley"
VAR CharlieFriendship = 0
VAR NatalieFriendship = 0
VAR JackeFriendship = 0

VAR dinnerready = false

#cutscene:on

-> START

=== START ===

Okay, I need you to try and relax. #portrait:natalie_neutral

You find yourself unable to move as this woman stares down at you. Has she strapped you down? #portrait:default

You want me to relax? Are you serious?! How am I supposed to relax right now?!  #portrait:ashley_angry

I know, I know. Just try, okay? This is only gonna hurt more if you’re tense. #portrait:natalie_neutral

Hurt…? What are you doing that’s gonna hurt?! I thought I was getting exiled to Earth… #portrait:ashley_shock

You are. I’m only here to fraction your chip before they send you off. #portrait:natalie_neutral

…What is that supposed to mean? #speaker:{playerName} #portrait:ashley_shock

It’s just to limit your abilities while you’re among the Earthlings. #speaker:Natalie #portrait:natalie_neutral

We won’t leave you with nothing, that’d just be cruel. But we do take precautions like this to weaken you before you’re sent away. 

It’ll be like having half of a chip. 

That’s sick… Please, you can’t do this to me. I didn’t do anything wrong! #speaker:{playerName} #portrait:ashley_shock

We both know that’s not true. I’m sorry, but I’m just doing my job. #speaker:Natalie #portrait:natalie_annoyed

Now seriously, you need to stop tensing up this much… #speaker:Natalie

    * Yeah, right. You try relaxing while someone’s trying to rip your chip out. #speaker:{playerName} #portrait:ashley_angry
    
        ~ NatalieFriendship -= 10
        
        Okay well, that’s a little vulgar. It’s more nuanced than that. #speaker:Natalie #portrait:natalie_angry
        
        Fractioning isn’t “ripping a chip out,” it’s more like severing it and storing the removed components in a safe location while you’re away.  #portrait:natalie_neutral
        
        Which for you… is most likely indefinitely. #portrait:natalie_angry
        
        ... #speaker:{playerName} #portrait:ashley_angry
    
    * Tell me what you’re doing, then. And be specific! #speaker:{playerName} #portrait:ashley_angry
        
        I’m very thoroughly trained to work with people’s chips. Fractioning is no exception. #speaker: Natalie #portrait:natalie_neutral
        
        I just extract the portion of the chip that I’m assigned to remove, and then it’s stored safely here at The Haevan while you get exiled down to Earth.
        
        That’s all there is to it. 
        
        Now please calm down so I can do this… #speaker:Natalie #portrait:natalie_annoyed
        
        ... #speaker:{playerName} #portrait:ashley_sad

    * I’m trying my best, okay? I’m too stressed out to relax right now… #speaker:{playerName} #portrait:ashley_sad
    
        ~ NatalieFriendship += 10
    
        I understand, this must be a lot for you. #speaker:Natalie #portrait:natalie_worried
        
        I assure you, I am a trained professional. You have nothing to be worried about, okay? Just try and take deep breaths. #portrait:natalie_neutral
        
        ... #speaker:{playerName} #portrait:ashley_sad

* [Stay Silent]

- The woman rests a hand on your chest as a bright mix of yellow and blue glow around the contact. You feel a sharp, brutally painful sensation as the glow gets stronger and stronger. From the looks of it, the woman is experiencing the same pain. #speaker:Narrator #portrait:default

tch... #speaker:Natalie #portrait:natalie_annoyed

Aaahhh!! #speaker:{playerName} #portrait:ashley_annoyed

The lights begin to die down as you feel a powerlessness beginning to seep into your muscles. The procedure has certainly left you weaker than you have ever been before. As the pain subsides, you try to move and fight back, but find yourself mentally and physically incapable. #speaker:Narrator #portrait:default

Hh… Hh… Okay… Okay, she's ready. #speaker:Natalie #portrait:natalie_worried

Anthony, you can come back in now and take her away. #portrait:natalie_neutral

You feel a grip on your arms similar to the one that brought you into this operation room earlier. Weakness continues to settle into your muscles, and your consciousness is fading quickly. When did you even get unstrapped from the table? #speaker:Narrator #portrait:default

She's all limp, is this normal? #speaker:Anthony

Yes. She'll need time to recuperate from the operation, and then she'll be fine. #speaker:Natalie #portrait:natalie_neutral

Consider yourself lucky you’ll have such an easy passenger. #portrait:natalie_happy

The rest of your journey to Earth was hazy as your mind and body alike continue to give out on you. There is no more fighting back, you’re headed to Earth. #speaker:Narrator #portrait:default

Hello? Are you okay? #speaker:Charlie #portrait:charlie_worried

#cutscene:fade_out

Ugh... #speaker:Ashley #portrait:ashley_annoyed

Earth to stranger! Are you okay?... #speaker:Charlie #portrait:charlie_worried

-> CharlieIntro

= CharlieIntro

    * Who are you? #speaker:{playerName} #portrait:ashley_neutral
 
    Name’s Charlie. What about yours? #speaker:Charlie #portrait:charlie_happy
    
    My name is {playerName}. #speaker:{playerName} #portrait:ashley_neutral
    
    Well, nice to meet you, {playerName}! #speaker:Charlie #portrait:charlie_cheery
    
    -> CharlieIntro
 
    * What's going on? #speaker:{playerName} #portrait:ashley_neutral
 
    Um… You looked like you were sleeping in the middle of Sweetlake Forest. I get enjoying the scenery and all, but today really isn’t the best day to do that. #speaker:Charlie #portrait:charlie_neutral
  
        ** Sweetlake Forest? #speaker:{playerName} #portrait:ashley_shock
    
        Yup! Practically the middle of nowhere, but it’s close enough to my house that I like to take walks here sometimes. #speaker:Charlie #portrait:charlie_happy
        -> CharlieIntro
 
    * I think I'm okay. #speaker:{playerName} #portrait:ashley_sad
 
    Good, I’m glad. You had me worried for a second there! #speaker:Charlie #portrait:charlie_cheery

- Are you not from around here or something? I don’t think I’ve ever seen you before. #portrait:charlie_neutral

Yeah, you could say I’m from pretty far away. #speaker:{playerName} #portrait:ashley_sad

Today’s not the day to be sleeping in the middle of the woods. I don't know if you've heard, but they're predicting lots of rain in a bit. You should probably head home soon. #speaker:Charlie #portrait:charlie_neutral

-> home

= home

    * I don’t have a home I can go back to. #speaker:{playerName} #portrait:ashley_sad
        
        Oh, well… I’m sorry to hear that. #speaker:Charlie #portrait:charlie_sad
    
    * I think I’d rather stay in the rain than go home. #speaker:{playerName} #portrait:ashley_sad
        
        ~ CharlieFriendship += 10
        Hah, I can understand that. Rain can be real nice to help get away from it all. #speaker:Charlie #portrait:charlie_cheery
    
    * Then why are you out here? #speaker:{playerName} #portrait:ashley_happy
    
        ~ CharlieFriendship += 5
        You caught me! Maybe it makes me a little strange, but I love walking in the rain. Something about it really helps me calm down. #speaker:Charlie #portrait:charlie_cheery
        -> home

-  I don’t want to leave you alone in a rainy forest though, so why don’t you come back to my house to wait out the storm? It’s not far from here, I’ll lead the way! #portrait:charlie_happy #next_waypoint:Charlie #quest_add:Q001

-> END

=== WELCOME ===

Alright, we're here! Come on in! #speaker:Charlie #portrait:charlie_cheery

Charlie! #speaker: Jacke #portrait:jacke_cheery

#next_waypoint:Jacke

You’re back before the rain even started, that’s so unlike you. Who’s this? #portrait:jacke_neutral

This is {playerName}, I met her out in the forest. She needs a spot to crash and wait out the storm. #speaker: Charlie #portrait:charlie_happy

{playerName}, this is my brother.

Name’s Jacke, nice to meet ya! #speaker: Jacke #portrait: jacke_cheery

    * Wow, you're really cool! #speaker: Ashley #portrait: ashley_neutral
        ~ JackeFriendship += 10
        
        Hahaha, thanks dude. You're not too bad yourself. #speaker: Jacke #portrait: jacke_cheery
        
    * Nice to meet you too. #speaker: Ashley #portrait: ashley_happy
    
    * Thank you for letting me stay here. #speaker: Ashley #portrait: ashley_neutral
        ~ JackeFriendship -= 5
        
        You seem shy, I promise I don’t bite. You don’t have to be all formal about thanking us, you know? It’s whatever. #speaker: Jacke #portrait: jacke_happy

- Well, I’m gonna go get dinner started. I’ll let you guys chat and get you when we’re ready to eat. #speaker: Charlie #portrait:charlie_happy 

#next_waypoint:Charlie 


-> END

=== JackeTalk ===
Hey, I’ve never been one for boring conversations. What do you say we play video games instead? Kill some time before dinner? #speaker: Jacke #portrait: jacke_neutral
    
    * Sure, sounds like fun! But you’d have to teach me how. #speaker: Ashley #portrait: ashley_happy
        ~ JackeFriendship += 10
        
        Alright! That’s what I’m talking about! #speaker: Jacke #portrait: jacke_cheery
        -> DinnerTime
        
    * Think we could talk a bit first? #speaker: Ashley #portrait:ashley_neutral
        ~ JackeFriendship -= 10
        Sure, go for it. #speaker: Jacke #portrait: jacke_neutral
        -> JackeTalk2
        
= JackeTalk2
    * Is it just you and Charlie that live here? #speaker: Ashley #portrait:ashley_neutral
        ~ JackeFriendship -= 20
        
        I don't see how that's any of your business. #speaker: Jacke #portrait:jacke_angry
        ->JackeTalk2
        
    * You should know where I’m from. #speaker: Ashley #portrait:ashley_sad
        
        Hey, it’s not my place to pry into your personal life. If you really wanna tell me then go for it, but you don’t have to. #speaker: Jacke #portrait: jacke_neutral
        
        **[Tell them] I’m from another planet, but I’m in pretty big trouble. I was exiled here earlier today, and your brother found me in the woods. #speaker: Ashley #portrait:ashley_sad
            ~ JackeFriendship += 10
            
            So... you’re an alien? #speaker: Jacke #portrait:jacke_shock
            
            Hahaha, I didn’t know you had such a sense of humor. Maybe you’re not so bad after all. #portrait:jacke_cheery
            
            ->JackeTalk2
        
        **[Don't tell them] ... #speaker: Ashley #portrait:ashley_sad
            ->JackeTalk2
    
    * Do you like it here? #speaker: Ashley #portrait:ashley_neutral
        ~ JackeFriendship += 5
        
        What, in Ember City? It’s fine I guess. City living isn’t that bad when you live on the outskirts of town like Charlie and I do. #speaker: Jacke #portrait:jacke_neutral
        ->JackeTalk2    
        
    * How about we play that game now? #speaker: Ashley #portrait:ashley_happy
        ~ JackeFriendship += 5
        
        You'll have to teach me how though! #portrait:ashley_cheery
        
        Oh, a woman after my own heart! You are SO on! #speaker: Jacke #portrait:jacke_happy
        ->DinnerTime
        

= DinnerTime
        
- Hey guys, I’ve got dinner ready! #speaker: Charlie #portrait:charlie_happy #next_waypoint:Jacke
#next_waypoint:Charlie
~ dinnerready = true
-> END

===not_ready===
Charlie is preparing dinner for the three of you. He seems pretty locked in. #speaker:Narrator #portrait:default 
->END

=== TRUTH ===

{dinnerready: ->ready | ->not_ready}

=== ready ===

Thank you for including me in dinner. #speaker:Ashley #portrait:ashley_happy

Of course! It’s no problem at all. #speaker:Charlie #portrait:charlie_happy

So Ashley, I know you mentioned you were from pretty far away. Where are you from, anyway?

If I told you, I don't think you would believe me… #speaker:Ashley #portrait:ashley_neutral

Why not? Are you like… from another country or something? #speaker:Charlie #portrait:charlie_happy

More like another planet. #speaker:Ashley #portrait:ashley_angry

Pfft, right. #speaker:Jacke #portrait:jacke_happy

Is this a joke or something? I don’t get it… #speaker:Charlie #portrait:charlie_neutral

I’m not joking! I’m from The Haevan, it’s another planet where humans live. I know Earthlings don’t really learn about us, but- #speaker:Ashley #portrait:ashley_neutral

That doesn’t make any sense. Why are you lying to us? #speaker:Charlie #portrait:charlie_angry

I’m not! You deserve honesty! #speaker:Ashley #portrait:ashley_angry

Are you crazy or something? Charlie, did you bring a psycho into our house? #speaker:Jacke #portrait:jacke_angry

Maybe this was a mistake… Look, I’m not gonna kick you out into the storm, but you can’t stay here. You’re kinda freaking us out. #speaker:Charlie #portrait:charlie_angry
 
I’ll pack a container of food for you and I’ll write down the address of a shelter not too far from here, okay?

Wait, I’m not trying to freak you out! I’m being serious! #speaker:Ashley #portrait:ashley_neutral

Be grateful I’m packing you food, okay? I’ve been awfully nice to you considering you’re a stranger from the woods who’s telling crazy stories to dodge questions about where you’re from… #speaker:Charlie #portrait:charlie_angry

I'm not dodging questions! #speaker:Ashley #portrait:ashley_neutral

Just get out, please… #speaker:Charlie #portrait:charlie_angry

#unlock_area:woods

-> END


=== WAIT ===

#next_waypoint:Charlie

Hey! Wait up! #speaker:Charlie #portrait:charlie_angry

I’m sorry, that was rude of me to kick you out so fast… I’ll help you get to the shelter. #portrait:charlie_neutral

#follower:Charlie

-> END

=== TutorialFight ===

What the hell is that?! #speaker: Charlie #portrait:charlie_angry

I… I don’t know! #speaker: Ashley #portrait:ashley_angry

What do we do?! #speaker: Charlie #portrait:charlie_angry

Stay behind me, I’ll handle this! #speaker: Ashley #portrait:ashley_angry

-> END


=== AFTERFIGHT ===

Phew… How… How did you do all that?! You were so fast, I don’t understand. #speaker:Charlie #portrait:charlie_angry

Now you must believe me. I’m not from here, I’m from The Haevan. #speaker:Ashley #portrait:ashley_angry

This again? #speaker:Charlie #portrait:charlie_angry

I’m serious! I’m sure you have questions, and I’m happy to answer them. #speaker:Ashley #portrait:ashley_angry

-> QUESTIONS

= QUESTIONS

* What even is “The Haevan?” #speaker:Charlie #portrait:charlie_neutral
    
    It’s another planet where humans live, and everyone that lives there has their own implants that give them specific talents. #speaker:Ashley #portrait:ashley_neutral

    VAR  followup = true

    -> QUESTIONS

* {followup} So, what is your talent then? Speed? #speaker:Charlie #portrait:charlie_neutral

    …For simplicity’s sake, sure. It’s a little more nuanced than that, at least in my case, but yeah. #speaker:Ashley #portrait:ashley_neutral

    -> QUESTIONS

* This doesn’t make any sense. We didn’t even know that alien life existed, let alone ones that are so similar to humans. #speaker:Charlie #portrait:charlie_angry

    I am human, Charlie, everyone from The Haevan is. And Earthlings don’t know about us because your technology hasn’t advanced like ours has. You guys barely even have space travel! #speaker:Ashley #portrait:ashley_neutral

    -> QUESTIONS

* Do you have any idea what that thing was? #speaker:Charlie #portrait:charlie_neutral

    I wish I did, but no. I’ve never seen anything like this before. I won’t lie, it’s pretty scary. #speaker:Ashley #portrait:ashley_angry

    -> QUESTIONS

* Okay, I guess I kinda have to believe you now. #speaker:Charlie #portrait:charlie_neutral

- Phew… Thank you. I’m sorry you had to deal with all this. I’ll go, I don’t want to put you in any more danger. #speaker:Ashley #portrait:ashley_happy

Hold on, you don’t have to go. I was quick to judge you, and I’m sorry. You’ve gotta admit it seems hard to believe. #speaker:Charlie #portrait:charlie_neutral

I knew the Earthlings didn’t know about us, but you’re right, I didn’t consider just how hard it might be to convince one of them that we’re real. You all seem kinda stubborn, huh? #speaker:Ashley #portrait:ashley_neutral

Gee… Thanks. Look, if those things come back, I don’t want you out here on your own. And I definitely don’t want them coming after us without you around. I can’t put Jacke in that kind of danger! #speaker:Charlie #portrait:charlie_neutral

Please, come back to the house. You can stay with us as long as you want.

Really? Thank you so much! I really appreciate it. #speaker:Ashley #portrait:ashley_happy

Of course. Now let's get out of this storm before that thing wakes up. #speaker:Charlie #portrait:charlie_happy

#quest_add:Q002

-> END
