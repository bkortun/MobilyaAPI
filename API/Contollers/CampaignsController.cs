﻿using Application.Features.Campaigns.Commands.CreateCampaign;
using Application.Features.Campaigns.Commands.DeleteCampaign;
using Application.Features.Campaigns.Commands.UpdateCampaign;
using Application.Features.Campaigns.Commands.UploadCampaignImage;
using Application.Features.Campaigns.Dtos;
using Application.Features.Campaigns.Models;
using Application.Features.Campaigns.Query.ListByIdCampaign;
using Application.Features.Campaigns.Query.ListCampaign;
using Application.Features.Campaigns.Query.ListCampaignImage;
using Application.Features.Images.Commands.Upload;
using Application.Features.Images.Models;
using Application.Features.ProductImages.Models;
using Application.Features.ProductImages.Queries.ListProductProductImage;
using Azure.Core;
using Core.Application.Requests;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCampaignCommandRequest request)
        {
            CreateCampaignDto result = await Mediator.Send(request);
            return Created("", result);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCampaignCommandRequest request)
        {
            DeleteCampaignDto result = await Mediator.Send(request);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCampaignCommandRequest request)
        {
            UpdateCampaignDto result = await Mediator.Send(request); 
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> List([FromQuery] PageRequest pageRequest)
        {
            ListCampaignQueryRequest request = new() { PageRequest = pageRequest };
            ListCampaignModel result = await Mediator.Send(request);
            return Ok(result);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> ByIdList([FromRoute] ListByIdCampaignQueryRequest request)
        {
            ListByIdCampaignDto result = await Mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UploadCampaignImage([FromQuery] UploadCampaignImageCommandRequest request)
        {
            request.Files = Request.Form.Files;
            UploadCampaignImageDto response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{CampaignId}")]
        public async Task<IActionResult> ListCampaignImage([FromRoute] ListCampaignImageQueryRequest request)
        {
            ListCampaignImageModel response = await Mediator.Send(request);
            return Ok(response);
        }
    }
}
