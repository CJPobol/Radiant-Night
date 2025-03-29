CONST playerName = "Ashley"
VAR JackeFriendship = 0

-> WELCOME

=== WELCOME ===

Alright, we're here! Come on in! #speaker:Charlie #portrait:charlie_cheery

Charlie! #speaker: Jacke #portrait:jacke_cheery

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

-> END
