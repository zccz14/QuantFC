using System;

namespace QuantFC
{
    public static partial class X
    {
        public static ImplementedNode Implement(this INode node, Func<int> func) => new LambdaImplementedNode(node, func);
        public static ActionNode Implement(this INode node, Action action) => new LambdaActionNode(node, action);
        public static PredicateNode Implement(this INode node, Func<bool> predicate) => new LambdaPredicateNode(node, predicate);
        public static SwitchNode Implement(this INode node, params Func<bool>[] predicates) => new LambdaSwitchNode(node, predicates);

        public static int Inject(this INode node, IGraphBuilder builder) => builder.ImportNode(node);
    }
}
