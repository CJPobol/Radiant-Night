CONST playerName = "Ashley"
VAR CharlieFriendship = 0
VAR NatalieFriendship = 0

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

-> choice1

=== choice1 ===
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

=== CharlieIntro ===

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
#quest_add:Q001