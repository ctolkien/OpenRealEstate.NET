﻿using System.Diagnostics;
using OpenRealEstate.Core.Primitives;

namespace OpenRealEstate.Core.Models
{
    public class Communication : BaseModifiedData
    {
        private const string DetailsName = "Details";
        private const string CommunicationTypeName = "CommunicationType";

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly EnumNotified<CommunicationType> _communicationType;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly StringNotified _details;

        public Communication()
        {
            _details = new StringNotified(DetailsName);
            _details.PropertyChanged += ModifiedData.OnPropertyChanged;

            _communicationType = new EnumNotified<CommunicationType>(CommunicationTypeName);
            _communicationType.PropertyChanged += ModifiedData.OnPropertyChanged;
        }

        public string Details
        {
            get { return _details.Value; }
            set { _details.Value = value; }
        }

        public CommunicationType CommunicationType
        {
            get { return _communicationType.Value; }
            set { _communicationType.Value = value; }
        }

        public void Copy(Communication newCommunication, bool isModifiedPropertiesOnly = true)
        {
            ModifiedData.Copy(newCommunication, this, isModifiedPropertiesOnly);
        }

        public void ClearAllIsModified()
        {
            ModifiedData.ClearModifiedPropertiesAndCollections();
        }
    }
}