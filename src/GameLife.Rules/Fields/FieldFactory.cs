﻿using GameLife.Rules.Rules;

namespace GameLife.Rules.Fields;

public static class FieldFactory
{
    public static Field Create(int width, int height, RuleSet ruleSet)
    {
        var rule = GetRule(ruleSet);
        var field = new Field(width, height, rule);

        rule.InitializeField(field);

        return field;
    }

    private static IRule GetRule(RuleSet ruleSet)
    {
        return ruleSet switch
        {
            RuleSet.Basic => new BasicRule(),
            RuleSet.Test => new TestRule(),
            _ => new BasicRule()
        };
    }
}