{'type':'CustomDialog',
    'name':'Template',
    'title':'Setlist Editor',
    'position':(119, 167),
    'size':(408, 370),
    'components': [

{'type':'StaticText', 
    'name':'numtopass_textCopy', 
    'position':(55, 60), 
    'text':'on difficulty:', 
    },

{'type':'StaticText', 
    'name':'defaultunlocked_text', 
    'position':(35, 140), 
    'text':'Default Unlocked:', 
    },

{'type':'Spinner', 
    'name':'defaultunlocked_spinner', 
    'position':(135, 135), 
    'size':(46, -1), 
    'max':100, 
    'min':0, 
    'value':0, 
    },

{'type':'StaticLine', 
    'name':'StaticLine1', 
    'position':(0, 100), 
    'size':(410, -1), 
    'layout':'horizontal', 
    },

{'type':'Spinner', 
    'name':'numpass_spinner', 
    'position':(135, 10), 
    'size':(46, -1), 
    'max':100, 
    'min':0, 
    'value':0, 
    },

{'type':'StaticText', 
    'name':'numtopass_text', 
    'position':(10, 15), 
    'text':'Num required to pass :', 
    },

{'type':'RadioGroup', 
    'name':'diffradio', 
    'position':(135, 40), 
    'size':(247, 49), 
    'items':['Easy', 'Medium', 'Hard', 'Expert'], 
    'label':'Difficulty', 
    'layout':'horizontal', 
    'max':1, 
    'stringSelection':'Easy', 
    },

{'type':'StaticText', 
    'name':'numpertier_text', 
    'position':(45, 190), 
    'text':'Songs per Tier :', 
    },

{'type':'TextField', 
    'name':'tiername_textfield', 
    'position':(270, 160), 
    'size':(125, -1), 
    },

{'type':'Spinner', 
    'name':'songspertier_spinner', 
    'position':(136, 185), 
    'size':(46, -1), 
    'max':100000000, 
    'min':0, 
    'value':0, 
    },

{'type':'StaticText', 
    'name':'song_text', 
    'position':(90, 240), 
    'text':'Song :', 
    },

{'type':'StaticText', 
    'name':'songnum_text', 
    'position':(50, 215), 
    'text':'Song Number :', 
    },

{'type':'Choice', 
    'name':'songchoice', 
    'position':(135, 235), 
    'items':[], 
    },

{'type':'Choice', 
    'name':'songnumchoice', 
    'position':(135, 210), 
    'items':[], 
    },

{'type':'StaticText', 
    'name':'tier_text', 
    'position':(95, 165), 
    'text':'Tier :', 
    },

{'type':'Choice', 
    'name':'tierchoice', 
    'position':(135, 160), 
    'items':[], 
    },

{'type':'StaticText', 
    'name':'setlist_text', 
    'position':(75, 115), 
    'text':'Set List :', 
    },

{'type':'Choice', 
    'name':'setlistchoice', 
    'position':(135, 110), 
    'items':[], 
    },

{'type':'Button', 
    'id':5100, 
    'name':'btnOK', 
    'position':(20, 280), 
    'default':1, 
    'label':'OK', 
    },

{'type':'Button', 
    'id':5101, 
    'name':'btnCancel', 
    'position':(105, 280), 
    'label':'Cancel', 
    },

] # end components
} # end CustomDialog