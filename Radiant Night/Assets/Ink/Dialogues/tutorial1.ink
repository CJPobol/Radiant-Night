CONST playerName = "Ashley"
VAR CharlieFriendship = 0

Hello? Are you okay? #speaker:Charlie #portrait:charlie_worried

Ugh... #speaker:Ashley #portrait:ashley_annoyed

Earth to stranger! Are you okay?... #speaker:Charlie #portrait:charlie_worried

-> START

=== START ===

    * Who are you? #speaker:{playerName} #portrait:ashley_neutral
 
    Name’s Charlie. What about yours? #speaker:Charlie #portrait:charlie_happy
    
    My name is {playerName}. #speaker:{playerName} #portrait:ashley_neutral
    
    Well, nice to meet you, {playerName}! #speaker:Charlie #portrait:charlie_cheery
    
    -> START
 
    * What's going on? #speaker:{playerName} #portrait:ashley_neutral
 
    Um… You looked like you were sleeping in the middle of Sweetlake Forest. I get enjoying the scenery and all, but today really isn’t the best day to do that. #speaker:Charlie #portrait:charlie_neutral
  
        ** Sweetlake Forest? #speaker:{playerName} #portrait:ashley_shock
    
        Yup! Practically the middle of nowhere, but it’s close enough to my house that I like to take walks here sometimes. #speaker:Charlie #portrait:charlie_happy
        -> START
 
    * I think I'm okay. #speaker:{playerName} #portrait:ashley_sad
 
    Good, I’m glad. You had me worried for a second there! #speaker:Charlie #portrait:charlie_cheery

- Are you not from around here or something? I don’t think I’ve ever seen you before. #portrait:charlie_neutral

Yeah, you could say I’m from pretty far away. #speaker:{playerName} #portrait:ashley_sad

Today’s not the day to be sleeping in the middle of the woods. I don't know if you've heard, but they're predicting lots of rain in a bit. You should probably head home soon. #speaker:Charlie #portrait:charlie_neutral

-> home

=== home ===

    * I don’t have a home I can go back to. #speaker:{playerName} #portrait:ashley_sad
        
        Oh, well… I’m sorry to hear that. #speaker:Charlie #portrait:charlie_sad
    
    * I think I’d rather stay in the rain than go home. #speaker:{playerName} #portrait:ashley_sad
        
        ~ CharlieFriendship += 10
        Hah, I can understand that. Rain can be real nice to help get away from it all. #speaker:Charlie #portrait:charlie_cheery
    
    * Then why are you out here? #speaker:{playerName} #portrait:ashley_happy
    
        ~ CharlieFriendship += 5
        You caught me! Maybe it makes me a little strange, but I love walking in the rain. Something about it really helps me calm down. #speaker:Charlie #portrait:charlie_cheery
        -> home

-  I don’t want to leave you alone in a rainy forest though, so why don’t you come back to my house to wait out the storm? It’s not far from here, I’ll lead the way! #portrait:charlie_happy

-> END
