---
layout: nav
title: Game Development Platform
---

{% include gdp-registration.html %}

## What is the EventHorizon Game Development Platform

This is a set of micro-services that can be used to create any type of game, with an emphasis on Multiplayer and world areas with an easy to use user interface.

## Architecture Overview

The architecture is broken up into multiple services/servers, giving you a managed environment to create a multiple player game, or single player if you so wish, all bundled into an easy to use platform to create any game you wish.

### High-Level Platform Architecture

![Game Development Platform Architecture Diagram](/image/architecture/GameDevPlatform.png)

The platform is deployed on a Kubernetes Cluster, this give the platform the flexibility to deploy multiple platforms at once for completely different users. Built into the infrastructure are Platform provided services; the Cloud Platform, Identity Server and Monitoring are all shared by the Game Platforms. 

This setup allows for the separation user specific instances, but also allowing  for efficient usage of raw compute resources. Using Kubernetes as the infrastructure, the platform is also able to do rolling updates, this allows for near zero downtime of updates to different parts of the infrastructure and services. 

The applications on the platform have been developed with this architecture in mind, so lost connections will auto reconnect.

### Identity Service

The Identity Service is a stand-alone service that controls the Authentication and Authorization of all the Platform services, be it player or server-to-server communication. The Identity Service provided Login functionality for the players and administrators allowing for authorization of roles to be managed by a central service. 

### Cloud Platform Service

This is the entry point Dashboard for platform administrators, platform owners can use this dashboard to get access to their Account. The platform includes a list of all of created services and their current state on the platform. Account administration is also done here, like approving new registration requests or starting update platform request processing.

### Game Client Service

This is the beginning GUI that a player will interface with when starting a game. This service contains all the Game Assets, be that scripts, images, models, etc. The Engine service contains all the base logic to interface with the rest of the Platform. After logging in and starting the Game a player will interface with the Core service and on successfully lookup of their client information will be connected to their Zone server.

### Asset Server

This server is a centralized location for all game assets, like terrain textures, player models, and pixel/vertex shaders used by different platform features. It has an API used by the editor that will allow for custom assets to be uploaded and exposed to the Game client as assets.

### Core Service

The Core service is the the central service all other services interface to. This service returns the details about a client connection, like their state in the Platform and Zone location information. Zone services will also connect and is used for keep alive and connection information about other platform services.

### Zone Service

The Zone services is a Game world location. The zone server contains unique information about what a Client will interact with in the game world. The Zone server contains Agents, Player, Scripts, Logic, GUI, etc of the game world helping to localize the state of the world in a single Server instances.

The server state can also be tweaked with CSX/C# Scripts as well. These scripts can be used to run different logic on the server/game client and hot reloaded while the server is running.

Configuration for the different systems, services, and scripts are JSON based, allow for human readable configuration. Most if not all the configuration can be edited from the browser based Editor, more details to be provided by the Editor Server section.

### Player Service

The Player service hold all of the player/client information for the whole platform. As details about a player for a Platform change, this service will make sure it is persisted between logins, and platform updates.

### Agent Service

The Agent services hold information about Global Agents, these agents are similar to traveling NPC's, and are more of a template to be used for global NPC's on the platform. Currently they are just like other Agents in a Zone, but will be enhanced to be a template for global Enemies, Trader, Quest Givers, etc. This service is more for multi-server game environments, this allows for a single NPC to move between different game zones.

### Editor Service

This services allows for Administrators of the Platform to manage the Player, Agent, Asset and Zone details. This service helps to keep track of Zone details, and contains a list of all currently connected Zone available on the Core server. This connection to the Core service allows for a holistic view of all the Zone/Game server attached to the platform. 

The Editor also contains a variety of tools that can be used to easily manage the platform, for zones you can edit files directly on the file system, and update static work entities in a zone. This service is the one stop shop for all your game creation needs.
