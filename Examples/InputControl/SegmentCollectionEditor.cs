using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Text;

namespace InputControl
{
    public class SegmentCollectionEditor : CollectionEditor
    {
        public SegmentCollectionEditor() : base(typeof(List<Segment>))  {  }

        public override object? EditValue(ITypeDescriptorContext? context, IServiceProvider provider, object? value)
        {
            object? result = base.EditValue(context, provider, value);
            if (context?.Instance is Scene scene)
            {
                scene.NotifySegmentChanged();
            }
            // Custom editing logic can be added here if needed
            return result;
        }
    }
}
