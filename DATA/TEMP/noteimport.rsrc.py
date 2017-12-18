{'type':'CustomDialog',
    'name':'Template',
    'title':'Dialog Template',
    'position':(134, 254),
    'size':(293, 158),
    'components': [

{'type':'StaticText', 
    'name':'Midi_file_textCopy', 
    'position':(10, 60), 
    'text':'Offset :', 
    },

{'type':'StaticText', 
    'name':'Midi_file_text', 
    'position':(10, 30), 
    'text':'Midi file :', 
    },

{'type':'Spinner', 
    'name':'offset_spinner', 
    'position':(66, 55), 
    'max':100000, 
    'min':0, 
    'value':0, 
    },

{'type':'Button', 
    'name':'mid_browse', 
    'position':(195, 25), 
    'label':'Browse', 
    },

{'type':'TextField', 
    'name':'midtext', 
    'position':(65, 25), 
    'size':(115, -1), 
    },

{'type':'Button', 
    'id':5100, 
    'name':'btnOK', 
    'position':(15, 100), 
    'default':1, 
    'label':'OK', 
    },

{'type':'Button', 
    'id':5101, 
    'name':'btnCancel', 
    'position':(105, 100), 
    'label':'Cancel', 
    },

] # end components
} # end CustomDialog
