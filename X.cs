using System;

namespace QuantFC
{
    public static partial class X
    {
        public static ImplementedNode Implement(this INode node, Func<int> func) => new LambdaImplementedNode(node, func);
        public static ActionNode Implement(this INode node, Action action) => new LambdaActionNode(node, action);
        public static PredicateNode Implement(this INode node, Func<bool> predicate) => new LambdaPredicateNode(node, predicate);
        public static SwitchNode Implement(this INode node, params Func<bool>[] predicates) => new LambdaSwitchNode(node, predicates);

        public static void Implement(this IGraphBuilder builder, int node, Action action) =>
            builder.SubstituteNode(node, builder.GetNode(node).Implement(action));

        public static void Implement(this IGraphBuilder builder, int node, Func<int> func) =>
            builder.SubstituteNode(node, builder.GetNode(node).Implement(func));

        public static void Implement(this IGraphBuilder builder, int node, Func<bool> predicate) =>
            builder.SubstituteNode(node, builder.GetNode(node).Implement(predicate));

        public static void Implement(this IGraphBuilder builder, int node, params Func<bool>[] predicates) =>
            builder.SubstituteNode(node, builder.GetNode(node).Implement(predicates));

        public static int Inject(this INode node, IGraphBuilder builder) => builder.ImportNode(node);
    }
}
