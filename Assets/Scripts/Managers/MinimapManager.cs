using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Managers
{
    class MinimapManager : Singleton<MinimapManager>
    {
        public UIMinimap minimap;
        private Collider minimapBoundingBox;
        public Collider MinimapBoundingBox
        {
            get { return minimapBoundingBox; }
        }

        public Transform Playertransform 
        {
            get 
            {
                if (User.Instance.CurrentCharacterObjcet == null)
                    return null;
                return User.Instance.CurrentCharacterObjcet.transform;
            }
        }

        public Sprite LoadCurrentMinimap()
        {
            return //Resources.Load<Sprite>("UI/Minimap/" + User.Instance.CurrentMapData.Minimap);
                Resloader.Load<Sprite>("UI/Minimap/" + User.Instance.CurrentMapData.MiniMap);
        }

        public void UpdateMinimap(Collider minimapBoundingBox)
        {
            this.minimapBoundingBox = minimapBoundingBox;
            if(this.minimap != null) 
                this.minimap.UpdateMap();
        }
    }
}
