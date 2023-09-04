Follow the convensional commit format for pull requests as well.

## Azure Pipelines
Rename the `.github` folder to `.azuredevops` when using Azure Pipelines.

- `pipelines/` - YAML Pipeline code goes here.
  - `jobs/` - Reusable Jobs.
  - `steps/` - Reusable Steps.

## GitHub Actions

- `workflows` - GitHub Actions code goes here.
  > Learn more about the difference between Reusable Workflows vs. Composite Actions.
  > https://github.blog/2022-02-10-using-reusable-workflows-github-actions/#key-differences-between-reusable-workflows-and-composite-actions