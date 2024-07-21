CONST playerName = "Ashley"
VAR CharlieFriendship = 0

Hello? Are you okay? #speaker: Charlie

Earth to stranger! Are you okay?... #speaker: Charlie

-> START

=== START ===

    * Who are you? 
 
    Name’s Charlie. What about yours? #speaker: Charlie
    
    My name is {playerName}. #speaker: Player
    
    Well, nice to meet you, {playerName}! #speaker: Charlie
    
    -> START
 
    * What's going on?
 
    Um… You looked like you were sleeping in the middle of Sweetlake Forest. I get enjoying the scenery and all, but today really isn’t the best day to do that. #speaker: Charlie
  
        ** Sweetlake Forest?
    
        Yup! Practically the middle of nowhere, but it’s close enough to my house that I like to take walks here sometimes… #speaker: Charlie
        -> START
 
    * I think I'm okay
 
    Good, I’m glad. You had me worried for a second there! #speaker: Charlie

- Are you not from around here or something? I don’t think I’ve ever seen you before. #speaker: Charlie

Yeah, I’m… I’m from pretty far away. 

Today’s not the day to be sleeping in the middle of the woods. You do realize it’s about to rain, right? You should probably head home soon. #speaker: Charlie

-> home

=== home ===

    * I don’t have a home I can go back to.
        
        Oh, well… I’m sorry to hear that. #speaker: Charlie
    
    * I think I’d rather stay in the rain than go home.
        
        ~ CharlieFriendship += 10
        Hah, I can understand that. #speaker: Charlie
    
    * Then why are you out here?
        
        ~ CharlieFriendship += 5
        You caught me! What can I say, sometimes the rain helps calm me down. I’m the weirdo that actually likes walking in the rain, I guess. #speaker: Charlie
        -> home

-  I don’t want to leave you alone in a rainy forest though, so why don’t you come back to my house to wait out the storm? It’s not far from here, I’ll lead the way! #speaker: Charlie

-> END
