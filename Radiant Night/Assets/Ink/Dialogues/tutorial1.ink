CONST playerName = "Ashley"
VAR JackeFriendship = 0

-> START

=== START ===

Alright, we're here! Come on in! #speaker:Charlie #portrait:charlie_cheery

Charlie! #speaker: Jacke

You’re back before the rain even started, that’s so unlike you. Who’s this?

This is {playerName}, I met her out in the forest. She needs a spot to crash and wait out the storm. #speaker: Charlie #portrait:charlie_happy

{playerName}, this is my brother.

-> introChoice

=== introChoice ===
Name’s Jacke, nice to meet ya! #speaker: Jacke #portrait: jacke_cheery

    * Wow, you're really cool!
        ~ JackeFriendship += 10
        
        Hahaha, thanks dude. You're not too bad yourself. #speaker: Jacke #portrait: jacke_cheery
        
    * Nice to meet you too.
    
    * Thank you for letting me stay here.
        ~ JackeFriendship -= 5
        
        You seem shy, I promise I don’t bite. You don’t have to be all formal about thanking us, you know? It’s whatever. #speaker: Jacke #portrait: jacke_happy

- Well, I’m gonna go get dinner started. I’ll let you guys chat and get you when we’re ready to eat. #speaker: Charlie #portrait:charlie_happy

->JackeTalk

=== JackeTalk ===
Hey, I’ve never been one for boring conversations. What do you say we play video games instead? Kill some time before dinner? #speaker: Jacke #portrait: jacke_neutral
    
    * Sure, sounds like fun! But you’d have to teach me how. 
        ~ JackeFriendship += 10
        
        Alright! That’s what I’m talking about! #speaker: Jacke #portrait: jacke_cheery
        -> DinnerTime
        
    * Think we could talk a bit first? #speaker: Ashley #portrait:ashley_neutral
        ~ JackeFriendship -= 10
        Sure, go for it. 
        -> JackeTalk2
        
===JackeTalk2 ===
    * Is it just you and Charlie that live here?
        ~ JackeFriendship -= 20
        
        I don't see how that's any of your business. #speaker: Jacke #portrait:jacke_angry
        ->JackeTalk2
        
    * You should know where I’m from.
        
        Hey, it’s not my place to pry into your personal life. If you really wanna tell me then go for it, but you don’t have to.
        
        **[Tell them] I’m from another planet, but I’m in pretty big trouble. I was exiled here earlier today, and your brother found me in the woods.
            ~ JackeFriendship += 10
            
            So... you’re an alien? #speaker: Jacke #portrait:jacke_confused
            
            Hahaha, I didn’t know you had such a sense of humor. Maybe you’re not so bad after all. #portrait:jacke_cheery
            
            ->JackeTalk2
        
        **[Don't tell them]
            ->JackeTalk2
    
    * Do you like it here?
        ~ JackeFriendship += 5
        
        What, in Ember City? It’s fine I guess. City living isn’t that bad when you live on the outskirts of town like Charlie and I do.
        ->JackeTalk2    
        
    * How about we play that game now? #speaker: Ashley #portrait:ashley_neutral
        ~ JackeFriendship += 5
        
        You'll have to teach me how though! 
        
        Oh, a woman after my own heart! You are SO on! #speaker: Jacke #portrait:jacke_happy
        ->DinnerTime
        

=== DinnerTime ===
        
- Hey guys, I’ve got dinner ready!


-> END
