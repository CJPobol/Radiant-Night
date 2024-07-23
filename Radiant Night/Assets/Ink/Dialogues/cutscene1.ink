VAR NatalieFriendship = 0

#cutscene:true

-> START

=== START ===

Okay, I need you to try and relax. #speaker:Natalie

You find yourself unable to move as this woman stares down at you. Has she strapped you down? #speaker:Narrator #portrait:default

You want me to relax? Are you serious?! How am I supposed to relax right now?!  #speaker:Player #portrait:ashley_angry

I know, I know. Just try, okay? This is only gonna hurt more if you’re tense. #speaker: Natalie

Hurt…? What are you doing that’s gonna hurt?! I thought I was getting exiled to Earth… #speaker:Player #portrait:ashley_shock

You are. I’m only here to fraction your chip before they send you off. #speaker:Natalie

…What the fuck does that mean? #speaker:Player #portrait:ashley_shock

It’s just to limit your abilities while you’re among the Earthlings. We won’t leave you with nothing, that’d just be cruel. But we do take precautions like this to weaken you before you’re sent away. It’ll be like having half of a chip. #speaker:Natalie

That’s sick… Please, you can’t do this to me. I didn’t do anything wrong! #speaker:Player

We both know that’s not true. I’m sorry, but I’m just doing my job. #speaker:Natalie

-> choice

=== choice ===
Now seriously, you need to stop tensing up this much… #speaker:Natalie

    * Yeah, fucking right. You try relaxing while someone’s trying to rip your chip out. #speaker:Player
    
        ~ NatalieFriendship -= 10
        
        Okay well, that’s a little vulgar. It’s more nuanced than that. Fractioning isn’t “ripping a chip out,” it’s more like severing it and storing the removed components in a safe location while you’re away. Which for you… is most likely indefinitely. #speaker:Natalie
        
        Fuck you… #speaker:Player
    
    * Tell me what you’re doing, then. And be specific! #speaker:Player
        
        I’m very thoroughly trained to work with people’s chips. Fractioning is no exception. I just extract the portion of the chip that I’m assigned to remove, and then it’s stored safely here at The Haevan while you get exiled down to Earth. That’s all there is to it. #speaker: Natalie
        
        Now please calm down so I can do this… #speaker:Natalie
        
        ... #speaker:Player

    * I’m trying my best, okay? I’m too stressed out to relax right now… #speaker:Player
    
        ~ NatalieFriendship += 10
    
        I understand, this must be a lot for you. I assure you, I am a trained professional. You have nothing to be worried about, okay? Just try and take deep breaths. #speaker:Natalie
        
        ... #speaker:Player

* [Stay Silent] #speaker:Player 

- tch... #speaker:Natalie

Aaahhh!! #speaker:Player #portrait:ashley_annoyed

Hh… Hh… Okay… Okay, she's ready. #speaker:Natalie

Anthony, you can come back in now and take her away. 

You feel a grip on your arms similar to the one that brought you into this operation room earlier. Weakness settles into your muscles, and your consciousness is fading quickly. When did you get unstrapped from the table? #speaker:Narrator #portrait:default

She's all limp, is this normal? #speaker:Anthony

Yes. She'll need time to recuperate from the operation, and then she'll be fine. #speaker:Natalie

Consider yourself lucky you’ll have such an easy passenger. 

The rest of your journey to Earth was hazy as your mind and body alike continue to give out on you. There is no more fighting back, you’re headed to Earth. #speaker:Narrator #portrait:default

-> END
