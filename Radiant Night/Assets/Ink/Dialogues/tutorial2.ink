VAR JackeFriendship = 0

->JackeTalk

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
        
===JackeTalk2 ===
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
        

=== DinnerTime ===
        
- Hey guys, I’ve got dinner ready! #speaker: Charlie #portrait:charlie_happy

-> END

