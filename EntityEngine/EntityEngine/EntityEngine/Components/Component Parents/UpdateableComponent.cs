﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using EntityEngine.Components.Component_Parents.Entity_Bases;

namespace EntityEngine.Components.Component_Parents
{
    public class UpdateableComponent : IEntityComponent, IEntityUpdateable
    {
        //Parent of a component that needs to be updated but not drawn

        public string _name = "";
        public bool _enabled = true;
        public int _updateOrder = 0;

        public Entity _parent;

        public UpdateableComponent()
        {
            
        }
        public UpdateableComponent(Entity myParent)
        {
            _parent = myParent;
           
        }

        //Getters
        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public bool enabled
        {
            get
            {
                return _enabled;
            }
        }
        public int updateOrder
        {
            get
            {
                return _updateOrder;
            }
        }

        public Entity Parent
        {
            get
            {
                return _parent;
            }
            set
            {
                _parent = value;
            }
        }

        public virtual void Initialize()
        {
        }

        public virtual void Start()
        {
        }

        public virtual void Update(GameTime gameTime)
        {
        }
    }


}
